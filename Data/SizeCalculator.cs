using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;

namespace PresizelyWeb.Data
{
    public class SizeCalculator : IValidatableObject
    {
        [ConditionalRequired("IsTop", true, ErrorMessage = "Chest measurement is required for tops.")]
        [Range(70, 140, ErrorMessage = "Chest must be between 70 cm and 140 cm.")]
        public int? Chest { get; set; }

        [ConditionalRequired("IsTop", true, ErrorMessage = "Waist measurement is required.")]
        [Range(60, 150, ErrorMessage = "Waist must be between 60 cm and 150 cm.")]
        public int? Waist { get; set; }

        [ConditionalRequired("IsTop", true, ErrorMessage = "Sleeve length is required for tops.")]
        [Range(40, 70, ErrorMessage = "Sleeve length must be between 40 cm and 70 cm.")]
        public int? SleeveLength { get; set; }

        [ConditionalRequired("IsTop", false, ErrorMessage = "Waist measurement is required for trousers.")]
        [Range(65, 130, ErrorMessage = "Waist must be between 65 cm and 130 cm.")]
        public int? BottomsWaist { get; set; }

        [ConditionalRequired("IsTop", false, ErrorMessage = "Hips measurement is required for bottoms.")]
        [Range(70, 150, ErrorMessage = "Hips must be between 70 cm and 150 cm.")]
        public int? Hips { get; set; }

        [ConditionalRequired("IsTop", false, ErrorMessage = "Inseam is required for bottoms.")]
        [Range(50, 120, ErrorMessage = "Inseam must be between 50 cm and 120 cm.")]
        public int? Inseam { get; set; }

        public string RecommendedSize { get; set; }
        public string RecommendationMessage { get; set; }
        public bool IsTop { get; set; }
        private const int Tolerance = 10;

        [Required(ErrorMessage = "Height is required.")]
        [Range(140, 210, ErrorMessage = "Height must be between 140 cm and 210 cm.")]
        public int? Height { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        [Range(40, 200, ErrorMessage = "Weight must be between 40 kg and 200 kg.")]
        public int? Weight { get; set; }

        [Required(ErrorMessage = "Please select a fit preference.")]
        public string FitPreference { get; set; } = "Regular";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Console.WriteLine($"Validating FitPreference: {FitPreference}");
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(FitPreference))
                results.Add(new ValidationResult("Please select a fit preference.", new[] { nameof(FitPreference) }));

            return results;
        }

        public string MatchSize(string sizeChartJson)
        {
            if (!TryDeserializeSizeChart(sizeChartJson, out var sizeChart))
            {
                RecommendationMessage = "Invalid size chart data.";
                return "N/A";
            }

            Console.WriteLine("Starting FindBestFit...");

            // 🚨 **New Check for Bad Mismatches**
            if (CheckForExtremeMismatch(sizeChart))
            {
                RecommendationMessage = "Your height, weight, or measurements seem inconsistent. Please re-enter them.";
                Console.WriteLine("🚨 Extreme mismatch detected! Asking user to re-enter measurements.");
                return "N/A";
            }


            var bestMatch = FindBestFit(sizeChart, IsTop);
            if (bestMatch == null)
            {
                Console.WriteLine("No suitable size found.");
                RecommendationMessage = "No suitable size available based on provided measurements.";
                return "N/A";
            }
            Console.WriteLine($"Best Fit Before Adjustment: {bestMatch.Value.Key}");


            RecommendedSize = AdjustForFitPreference(bestMatch.Value.Key, sizeChart.Keys.ToList(), sizeChart);

            Console.WriteLine($"Final Recommended Size After Adjustment: {RecommendedSize}");
            return RecommendedSize;

        }

        private bool TryDeserializeSizeChart(string sizeChartJson, out Dictionary<string, Dictionary<string, int>> sizeChart)
        {
            sizeChart = null;
            if (string.IsNullOrWhiteSpace(sizeChartJson)) return false;

            try
            {
                sizeChart = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, int>>>(sizeChartJson);
                return sizeChart != null && sizeChart.Any();
            }
            catch
            {
                return false;
            }
        }

        private KeyValuePair<string, Dictionary<string, int>>? FindBestFit(Dictionary<string, Dictionary<string, int>> sizeChart, bool isTop)
        {
            Console.WriteLine("Entering FindBestFit...");
            const int tolerance = 5;//tolerance of 5cm
            var measurementMap = isTop
                ? new[] { (Chest, "ChestMin", "ChestMax", "Chest"), (Waist, "WaistMin", "WaistMax", "Waist") }
                : new[] { (BottomsWaist, "WaistMin", "WaistMax", "Waist"), (Hips, "HipsMin", "HipsMax", "Hips") };

            KeyValuePair<string, Dictionary<string, int>>? bestFit = null;
            KeyValuePair<string, Dictionary<string, int>>? alternativeFit = null;
            int smallestMismatch = int.MaxValue;
            var messages = new List<string>();

            foreach (var size in sizeChart)
            {
                Console.WriteLine($"Checking Size: {size.Key}");
                int mismatch = 0;
                bool allMeasurementsFit = true;

                foreach (var (value, minKey, maxKey, name) in measurementMap)
                {
                    if (!value.HasValue) continue;

                    int min = size.Value[minKey];
                    int max = size.Value[maxKey];

                    // Apply tolerance when checking if measurement fits within range
                    if (value < min - tolerance || value > max + tolerance)
                    {
                        mismatch += Math.Abs(value.Value - min);
                        allMeasurementsFit = false;
                    }
                }

                if (allMeasurementsFit)
                {
                    if (IsHeightWeightWithinSizeRange(size.Value))
                    {
                        if (FitPreference == "Regular")
                        {
                            RecommendationMessage = "This size provides a well-balanced fit.";
                            Console.WriteLine($"Perfect Fit Found: {size.Key}");
                            return size;
                        }
                        else
                        {
                            string adjustedSize = AdjustForFitPreference(size.Key, sizeChart.Keys.ToList(), sizeChart);
                            return sizeChart.FirstOrDefault(s => s.Key == adjustedSize);
                        }
                    }
                    else
                    {
                        alternativeFit = size; // Store as alternative, continue checking
                    }
                }

                if (mismatch < smallestMismatch)
                {
                    smallestMismatch = mismatch;
                    alternativeFit = size;
                }
            }

            // ✅ **Height-Based Adjustment (If No Perfect Fit)**
            if (alternativeFit.HasValue && Height.HasValue)
            {
                int avgHeight = 170;
                if (Height.Value > avgHeight + 10)
                {
                    messages.Add("You are taller than the average size recommendation. Recommendation is based on your height for better lenght.");
                    // ✅ Move to the next available size if possible
                    string nextSize = GetNextLargerSize(alternativeFit.Value.Key, sizeChart.Keys.ToList());
                    if (!string.IsNullOrEmpty(nextSize))
                    {
                        alternativeFit = sizeChart.FirstOrDefault(s => s.Key == nextSize);
                    }
                }
                else if (Height.Value < avgHeight - 10)
                {
                    messages.Add("You are shorter than the average size recommendation. Recommendation is based on your height for better lenght.");
                    string nextSize = GetNextSmallerSize(alternativeFit.Value.Key, sizeChart.Keys.ToList());
                    if (!string.IsNullOrEmpty(nextSize))
                    {
                        alternativeFit = sizeChart.FirstOrDefault(s => s.Key == nextSize);
                    }
                }
            }

            // ✅ **Return Alternative Fit (If Available)**
            if (alternativeFit.HasValue)
            {
                RecommendationMessage = string.Join(" ", messages);
                Console.WriteLine($"Best Alternative Fit: {alternativeFit?.Key}");
                return alternativeFit;
            }

            RecommendationMessage = "No suitable size available based on provided measurements.";
            return null;
        }

        private string GetNextLargerSize(string currentSize, List<string> availableSizes)
        {
            availableSizes = availableSizes.OrderBy(size => GetSizeOrder(size)).ToList();
            int currentIndex = availableSizes.IndexOf(currentSize);

            if (currentIndex >= 0 && currentIndex < availableSizes.Count - 1)
            {
                return availableSizes[currentIndex + 1]; // ✅ Move to next size
            }
            return currentSize; // ✅ If no larger size available, keep the same size
        }
        private string GetNextSmallerSize(string currentSize, List<string> availableSizes)
        {
            availableSizes = availableSizes.OrderBy(size => GetSizeOrder(size)).ToList();
            int currentIndex = availableSizes.IndexOf(currentSize);

            if (currentIndex >= 1 && currentIndex < availableSizes.Count + 1)
            {
                return availableSizes[currentIndex - 1]; // ✅ Move to next size
            }
            return currentSize; // ✅ If no lsmaller size available, keep the same size
        }


        private bool IsHeightWeightWithinSizeRange(Dictionary<string, int> sizeData)
        {
            if (!Height.HasValue || !Weight.HasValue) return false;

            int avgHeight = 170; // Standard height reference
            int avgWeight = AverageWeightForSize(RecommendedSize); // Expected weight for this size

            bool heightInRange = Height.Value >= avgHeight - 10 && Height.Value <= avgHeight + 10;
            bool weightInRange = Weight.Value >= avgWeight - 10 && Weight.Value <= avgWeight + 10;

            return heightInRange && weightInRange;
        }

        private string AdjustForFitPreference(string recommendedSize, List<string> availableSizes, Dictionary<string, Dictionary<string, int>> sizeChart)
        {
            if (string.IsNullOrWhiteSpace(FitPreference) || recommendedSize == "N/A")
                return recommendedSize;

            availableSizes = availableSizes.OrderBy(size => GetSizeOrder(size)).ToList();
            int currentIndex = availableSizes.IndexOf(recommendedSize);

            if (currentIndex == -1) return recommendedSize;

            bool useHips = !IsTop && (FitPreference == "Tight" || FitPreference == "Loose");
            int? primaryMeasurement = IsTop ? Chest : (useHips ? Hips : Waist);
            int min = sizeChart[recommendedSize].ContainsKey("PrimaryMin") ? sizeChart[recommendedSize]["PrimaryMin"] : int.MinValue;
            int max = sizeChart[recommendedSize].ContainsKey("PrimaryMax") ? sizeChart[recommendedSize]["PrimaryMax"] : int.MaxValue;

            Console.WriteLine($"Adjusting Fit: Current Size = {recommendedSize}, FitPreference = {FitPreference}");

            if (FitPreference == "Tight" && currentIndex > 0)
            {
                if (primaryMeasurement.HasValue)
                {
                   if (primaryMeasurement <= min - 3)
                   {
                        Console.WriteLine($"Moving One Size Down: {recommendedSize} → {availableSizes[currentIndex - 1]}");
                        return availableSizes[currentIndex - 1];
                   }

                   else if (primaryMeasurement >= max - 3)
                    {
                        Console.WriteLine($"Keeping the recommended size: {recommendedSize} → {availableSizes[currentIndex]}");
                        return availableSizes[currentIndex];
                    }
                }
            }
            else if (FitPreference == "Loose" && currentIndex < availableSizes.Count - 1)
            {
                if (primaryMeasurement.HasValue)
                {
                    if (primaryMeasurement >= max - 3)
                    {
                        Console.WriteLine($"Moving One Size Up: {recommendedSize} → {availableSizes[currentIndex + 1]}");
                        return availableSizes[currentIndex + 1];
                    }
                    else if(primaryMeasurement >= min + 3)
                    {
                        Console.WriteLine($"Keeping the recommended size: {recommendedSize} → {availableSizes[currentIndex]}");
                        return availableSizes[currentIndex];
                    }
                }
            }

            return recommendedSize;
        }

        private int AverageWeightForSize(string size)
        {
            if (string.IsNullOrEmpty(size))
            {
                Console.WriteLine("Warning: size is null or empty in AverageWeightForSize. Defaulting to 75.");
                return 75; // Default average weight
            }

            var weightRanges = new Dictionary<string, int>
    {
        { "S", 60 }, { "M", 75 }, { "L", 90 }, { "XL", 105 }
    };

            return weightRanges.ContainsKey(size) ? weightRanges[size] : 75;
        }

        private int GetSizeOrder(string size)
        {
            return size switch
            {
                "S" => 1,
                "M" => 2,
                "L" => 3,
                "XL" => 4,
                _ => int.MaxValue
            };
        }

        private bool CheckForExtremeMismatch(Dictionary<string, Dictionary<string, int>> sizeChart)
        {
            if (!Height.HasValue || !Weight.HasValue || !Chest.HasValue || !Waist.HasValue)
                return false; // Ensure all necessary values are present

            string estimatedSize = FindBestFit(sizeChart, IsTop)?.Key ?? "N/A";

            if (estimatedSize == "N/A")
                return false; // If no valid size is found, return false

            int estimatedWeight = AverageWeightForSize(estimatedSize);
            int sizeDifference = Math.Abs(Weight.Value - estimatedWeight);

            Console.WriteLine($"User's Weight: {Weight.Value}, Expected for {estimatedSize}: {estimatedWeight}, Difference: {sizeDifference}");

            // If weight mismatch is too large or height is extreme, flag as an issue
            if (sizeDifference > 20 || Height.Value < 150 || Height.Value > 200)
            {
                return true; // Measurements are unrealistic, user should re-enter
            }

            return false; // Otherwise, it's acceptable
        }
    }

    public class ConditionalRequiredAttribute : ValidationAttribute
    {
        private readonly string _conditionProperty;
        private readonly object _expectedValue;

        public ConditionalRequiredAttribute(string conditionProperty, object expectedValue)
        {
            _conditionProperty = conditionProperty;
            _expectedValue = expectedValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var conditionProperty = validationContext.ObjectType.GetProperty(_conditionProperty);
            if (conditionProperty == null)
                return new ValidationResult($"Property '{_conditionProperty}' not found.");

            var conditionValue = conditionProperty.GetValue(validationContext.ObjectInstance);

            if (Equals(conditionValue, _expectedValue) && value == null)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
