using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

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
            Console.WriteLine("🔍 Validating user input fields...");
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(FitPreference))
            {
                Console.WriteLine("❌ FitPreference is missing.");
                results.Add(new ValidationResult("Please select a fit preference.", new[] { nameof(FitPreference) }));
            }

            return results;
        }

        public bool TryDeserializeSizeChart(string sizeChartJson, out Dictionary<string, Dictionary<string, int>> sizeChart)
        {
            sizeChart = null;
            //Check if user input JSON is empty or null
            if (string.IsNullOrWhiteSpace(sizeChartJson))
            {
                Console.WriteLine("❌ Error: Size chart JSON is empty.");
                return false; // Return failure if no data is provided
            }

            try
            {   // Attempt to deserialize the JSON into a nested dictionary structure
                sizeChart = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, int>>>(sizeChartJson);
                if (sizeChart == null || !sizeChart.Any())
                {
                    Console.WriteLine("Error: Size chart JSON is empty or invalid.");
                    sizeChart = null;//Ensure output is null
                    return false;// Return failure if deserialization produced an empty object
                }
                return true; // Successfully deserialized size chart
            }
            catch (JsonException ex)
            { //  Handle JSON deserialization errors and log the issue
                Console.WriteLine($"❌ JSON deserialization error: {ex.Message}");
                sizeChart = null; // Ensure output is null on failure
                return false;// Return failure if JSON parsing fails
            }
        }

        public string MatchSize(string sizeChartJson)
        {
            RecommendedSize = null;
            RecommendationMessage = null;
     
            Console.WriteLine($"🔍 User Input:\n- Height: {Height} cm\n- Weight: {Weight} kg");
            if (IsTop)
            {
                Console.WriteLine($"- Chest: {Chest}\n- Waist: {Waist}\n- Sleeve Length: {SleeveLength}");
            }
            else
            {
                Console.WriteLine($"- Bottoms Waist: {BottomsWaist}\n- Hips: {Hips}\n- Inseam: {Inseam}");
            }

            Console.WriteLine($"- Fit Preference: {FitPreference}\n- IsTop: {IsTop}");
            if (!TryDeserializeSizeChart(sizeChartJson, out var sizeChart))
            {
                RecommendationMessage = "Invalid size chart data.";
                Console.WriteLine("❌ Error: Size chart could not be loaded.");
                return "N/A";
            }
            Console.WriteLine("✅ Size chart loaded successfully. Proceeding with size matching...");

            var bestMatch = FindBestSize(sizeChart, IsTop);

            if (bestMatch == null)
            {
                Console.WriteLine("❌ No suitable size found.");
                if (CheckForExtremeMismatch(sizeChart, null)) // Pass null to handle extreme cases
                {
                    return "N/A"; // `RecommendationMessage` set in `CheckForExtremeMismatch`
                }

                RecommendationMessage = "No suitable size available based on provided measurements.";
                return "N/A"; // ✅ If no size is found, return "N/A" properly
            }
            // ✅ If a size is found, check for extreme mismatch before proceeding
            if (CheckForExtremeMismatch(sizeChart, bestMatch))
            {
                return "N/A"; // Extreme mismatch detected; already set `RecommendationMessage`
            }

            Console.WriteLine($"🏷️ Recommended Size Before Fit Adjustment: {bestMatch?.Key}");

            if (FitPreference != "Regular")
            {
                RecommendedSize = AdjustForFitPreference(bestMatch.Value.Key, sizeChart.Keys.ToList(), sizeChart);
                Console.WriteLine($"🎯 Final Recommended Size After Fit Adjustment: {RecommendedSize}");
            }
            else
            {
                RecommendedSize = bestMatch.Value.Key;  // ✅ Keep the base size for "Regular" fit
                Console.WriteLine($"✅ No Fit Adjustment Needed. Final Recommended Size: {RecommendedSize}");
            }

            return RecommendedSize;
        }

        private bool CheckForExtremeMismatch(Dictionary<string, Dictionary<string, int>> sizeChart, KeyValuePair<string, Dictionary<string, int>>? bestFit)
        {
            Console.WriteLine("🔍 Checking for extreme mismatches...");

            if (Height == null || Weight == null) return false; // Ensure valid inputs

            string estimatedSize = bestFit?.Key ?? "N/A";
            int estimatedWeight = bestFit != null ? AverageWeightForSize(estimatedSize) : -1;
            int estimatedHeight = bestFit != null ? AverageHeightForSize(estimatedSize) : -1;

            // If no size was found, base the recommendation only on height & weight
            if (bestFit == null)
            {
                if (Weight.Value > 150 || Height.Value > 200)
                {
                    RecommendationMessage = "Your height or weight is beyond the standard range. Consider custom tailoring.";
                }
                else if (Weight.Value < 50 || Height.Value < 140)
                {
                    RecommendationMessage = "Your measurements are below the standard range. Consider youth sizes.";
                }
                else
                {
                    RecommendationMessage = "Your height, weight, or measurements seem inconsistent. Please check your measurements.";
                }
                return true;
            }

            // Proceed with normal mismatch checking if a size was found
            if (estimatedWeight == -1 || estimatedHeight == -1)
            {
                Console.WriteLine("⚠️ Skipping extreme mismatch check due to missing height/weight estimation.");
                return false;
            }

            int weightDifference = Math.Abs(Weight.Value - estimatedWeight);
            int heightDifference = Math.Abs(Height.Value - estimatedHeight);
            int tolerance = estimatedSize == "XL" ? 25 : 20;

            if (weightDifference > tolerance || heightDifference > tolerance)
            {
                if (Weight.Value > 100 && Height.Value < 165)
                {
                    RecommendationMessage = "Your weight is high relative to your height. Consider plus-size options.";
                }
                else if (Weight.Value < 50 && Height.Value > 190)
                {
                    RecommendationMessage = "Your weight is quite low for your height. A slim-fit option may be better.";
                }
                else
                {
                    RecommendationMessage = "Your height, weight, or measurements seem inconsistent.. Please check your measurements.";
                }
                return true;
            }

            return false;
        }


        private int AverageWeightForSize(string size)
        {
            if (string.IsNullOrWhiteSpace(size) || size == "N/A")
            {
                Console.WriteLine("⚠️ Warning: Invalid size passed to AverageWeightForSize. Skipping weight validation.");
                return -1; // ❌ Return -1 to indicate an invalid weight estimate
            }

            var weightRanges = new Dictionary<string, int>
    {
        { "S", 60 }, { "M", 75 }, { "L", 90 }, { "XL", 105 }, // Tops
                { "32", 65 }, { "34", 75 }, { "36", 85 }, { "38", 95 }  // ✅ Bottoms
    };

            return weightRanges.TryGetValue(size, out int weight) ? weight : -1; // ✅ Return -1 if size is not found
        }
        private int AverageHeightForSize(string size)
        {
            if (string.IsNullOrWhiteSpace(size) || size == "N/A")
            {
                Console.WriteLine("⚠️ Warning: Invalid size passed to AverageHeightForSize. Skipping height validation.");
                return -1;
            }

            // 🚀 Updated height mapping for both tops and bottoms
            var heightRanges = new Dictionary<string, int>
    {
        { "S", 160 }, { "M", 170 }, { "L", 180 }, { "XL", 185 },   // ✅ Tops
        { "32", 165 }, { "34", 170 }, { "36", 175 }, { "38", 180 }  // ✅ Bottoms
    };

            return heightRanges.TryGetValue(size, out int height) ? height : -1;
        }


        private bool IsHeightWeightWithinSizeRange(Dictionary<string, int> sizeData)
        {
            if (!Height.HasValue || !Weight.HasValue) return true; // ✅ Allow height/weight to be flexible

            int avgHeight = AverageHeightForSize(RecommendedSize);
            int avgWeight = AverageWeightForSize(RecommendedSize);

            if (avgWeight == -1) return true; // ✅ If weight cannot be determined, don't reject the size

            bool heightInRange = Height.Value >= avgHeight - 15 && Height.Value <= avgHeight + 15;
            bool weightInRange = Weight.Value >= avgWeight - 15 && Weight.Value <= avgWeight + 15;

            return heightInRange && weightInRange;
        }
        private KeyValuePair<string, Dictionary<string, int>>? FindBestSize(Dictionary<string, Dictionary<string, int>> sizeChart, bool isTop)
        {
            Console.WriteLine("Entering FindBestFit...");
            const int tolerance = 5;
            var measurementMap = isTop
                ? new[] { (Chest, "ChestMin", "ChestMax", "Chest"), (Waist, "WaistMin", "WaistMax", "Waist") }
                : new[] { (BottomsWaist, "WaistMin", "WaistMax", "Waist"), (Hips, "HipsMin", "HipsMax", "Hips") };

            KeyValuePair<string, Dictionary<string, int>>? bestFit = null;
            int smallestMismatch = int.MaxValue;

            foreach (var size in sizeChart)
            {
                Console.WriteLine($"Checking Size: {size.Key}");
                bool primaryMeasurementValid = false;
                bool allMeasurementsFit = true;
                int totalMismatch = 0;

                foreach (var (value, minKey, maxKey, name) in measurementMap)
                {
                    if (!value.HasValue) continue;

                    if (!size.Value.ContainsKey(minKey) || !size.Value.ContainsKey(maxKey))
                    {
                        Console.WriteLine($"❌ Missing key {minKey} or {maxKey} in size {size.Key}");
                        continue;
                    }

                    int min = size.Value[minKey];
                    int max = size.Value[maxKey];

                    Console.WriteLine($"🔍 {name}: Input={value}, Range=({min}-{max})");

                    if (name == "Chest" && isTop || name == "Waist" && !isTop)
                    {
                        primaryMeasurementValid = value >= min - tolerance && value <= max + tolerance;
                        if (!primaryMeasurementValid)
                        {
                            Console.WriteLine($"❌ {name} is out of range for size {size.Key}. Skipping size.");
                            allMeasurementsFit = false;
                            break;
                        }
                    }
                    else
                    {
                        if (value < min - tolerance || value > max + tolerance)
                        {
                            Console.WriteLine($"❌ {name} is out of range for size {size.Key}.");
                            allMeasurementsFit = false;
                        }
                        else
                        {
                            totalMismatch += Math.Min(Math.Abs(value.Value - min), Math.Abs(value.Value - max));
                        }
                    }
                }

                if (!allMeasurementsFit) continue;

                if (IsHeightWeightWithinSizeRange(size.Value) && totalMismatch < smallestMismatch)
                {
                    Console.WriteLine($"✅ Valid Size Found: {size.Key}");
                    bestFit = size;
                    smallestMismatch = totalMismatch;
                }
            }

            if (bestFit == null)
            {
                Console.WriteLine("❌ No valid size found.");
                return null;
            }

            Console.WriteLine($"✅ Best Fit Size Found: {bestFit.Value.Key}");
            return bestFit;
        }



        private string AdjustForFitPreference(string recommendedSize, List<string> availableSizes, Dictionary<string, Dictionary<string, int>> sizeChart)
        {
            Console.WriteLine($"🔍 Adjusting for fit preference: {FitPreference}");
            if (string.IsNullOrWhiteSpace(FitPreference) || recommendedSize == "N/A")
                return recommendedSize;

            availableSizes = availableSizes.OrderBy(size => GetSizeOrder(size)).ToList();
            int currentIndex = availableSizes.IndexOf(recommendedSize);

            if (currentIndex == -1) return recommendedSize;

            bool useHips = !IsTop && (FitPreference == "Tight" || FitPreference == "Loose");
            int? primaryMeasurement = IsTop ? Chest : (useHips ? Hips : BottomsWaist);
            int? secondaryMeasurement = IsTop ? Waist : (useHips ? BottomsWaist : Hips);
            int min = 0, max = 0;
            if (IsTop)
            {
                min = sizeChart[recommendedSize]["ChestMin"];
                max = sizeChart[recommendedSize]["ChestMax"];
            }
            else
            {
                string keyMin = useHips ? "HipsMin" : "WaistMin";
                string keyMax = useHips ? "HipsMax" : "WaistMax";
                min = sizeChart[recommendedSize][keyMin];
                max = sizeChart[recommendedSize][keyMax];
            }

            Console.WriteLine($"🔍 Adjusting Fit: Current Size = {recommendedSize}, FitPreference = {FitPreference}, " +
                $"Primary Measurement = {primaryMeasurement}");

            bool isLargestSize = currentIndex == availableSizes.Count - 1;

            if (FitPreference == "Tight" && currentIndex > 0)

            {
                string smallerSize = availableSizes[currentIndex - 1]; // Candidate size down
                int estimatedWeight = AverageWeightForSize(smallerSize);
                int estimatedHeight = AverageHeightForSize(smallerSize);

                if (primaryMeasurement.HasValue)
                {
                    if (primaryMeasurement <= min + 2)
                    {
                        Console.WriteLine($"🔎 Checking mismatch before sizing down: {recommendedSize} → {smallerSize}");
                        if (estimatedWeight != -1 && estimatedHeight != -1)
                        {
                            int weightDifference = Math.Abs(Weight.Value - estimatedWeight);
                            int heightDifference = Math.Abs(Height.Value - estimatedHeight);

                            int weightTolerance = 15; // Tight Fit = strict tolerance
                            int heightTolerance = 15;

                            Console.WriteLine($"🔹 Estimated Weight for {smallerSize}: {estimatedWeight} kg |" +
                                $" User Weight: {Weight.Value} kg (Difference: {weightDifference} kg)");
                            Console.WriteLine($"🔹 Estimated Height for {smallerSize}: {estimatedHeight} cm | " +
                                $"User Height: {Height.Value} cm (Difference: {heightDifference} cm)");

                            if (weightDifference > weightTolerance || heightDifference > heightTolerance)
                            {
                                Console.WriteLine($"❌ Cannot size down! Keeping {recommendedSize} to avoid mismatch.");
                                return recommendedSize; // ❌ Prevents mismatch, keeps original size
                            }
                        }

                        Console.WriteLine($"🔻 Sizing Down: {recommendedSize} → {smallerSize}");
                        return smallerSize; // ✅ Move to smaller size only if safe
                    }
                    else
                    {
                        Console.WriteLine($"✅ Keeping the recommended size: {recommendedSize} ");
                        return recommendedSize; // ✅ Keep the original size if not near lower bound
                    }
                }
            }

            else if (FitPreference == "Loose" && currentIndex < availableSizes.Count - 1)
            {
                string largerSize = availableSizes[currentIndex + 1];
                int estimatedWeight = AverageWeightForSize(largerSize);
                int estimatedHeight = AverageHeightForSize(largerSize);

                if (primaryMeasurement.HasValue && secondaryMeasurement.HasValue)
                {
                    bool primaryWithinTolerance = primaryMeasurement >= min - 5 && primaryMeasurement <= max + 5;
                    bool secondaryMatchesLargerSize = secondaryMeasurement >= sizeChart[largerSize]["WaistMin"] &&
                                                       secondaryMeasurement <= sizeChart[largerSize]["WaistMax"];
                    bool heightMatches = Height >= estimatedHeight - 5 && Height <= estimatedHeight + 5;
                    bool weightMatches = Weight >= estimatedWeight - 5 && Weight <= estimatedWeight + 5;
                    Console.WriteLine($"🔎 Loose Fit Check: {recommendedSize} → {largerSize}");
                    Console.WriteLine($"🔹 Primary Measurement: {primaryMeasurement} (Allowed range: {min - 5} to {max + 5})");
                    Console.WriteLine($"🔹 Secondary Measurement: {secondaryMeasurement} (Larger Size Range: {sizeChart[largerSize]["WaistMin"]}-{sizeChart[largerSize]["WaistMax"]})");
                    Console.WriteLine($"🔹 Height: {Height} (Expected: {estimatedHeight - 5} to {estimatedHeight + 5})");
                    Console.WriteLine($"🔹 Weight: {Weight} (Expected: {estimatedWeight - 5} to {estimatedWeight + 5})");


                    // ✅Prioritize Chest (Tops) or Hips (Bottoms) for Loose Fit
                    bool primaryNearUpperBound = primaryMeasurement.HasValue &&
                                                 primaryMeasurement >= max - 1 &&  // Instead of repeating lookup, use max
                                                 primaryMeasurement <= sizeChart[largerSize][IsTop ? "ChestMin" : "HipsMin"] + 5;

                    if ((primaryWithinTolerance && secondaryMatchesLargerSize && heightMatches && weightMatches) || primaryNearUpperBound)
                    {
                        Console.WriteLine($"🔺 Sizing Up: {recommendedSize} → {largerSize} (Primary Predictor & Secondary Measurement Support Larger Size)");
                        return largerSize;
                    }

                    // ✅ Allow Loose Fit Upgrade if Secondary, Height, and Weight match Larger Size
                    if (primaryWithinTolerance && secondaryMatchesLargerSize && heightMatches && weightMatches || primaryNearUpperBound)
                    {
                        Console.WriteLine($"🔺 Sizing Up: {recommendedSize} → {largerSize} (Secondary Measurement & Height/Weight match)");
                        return largerSize;
                    }

                    Console.WriteLine($"🔎 Checking mismatch before sizing up: {recommendedSize} → {largerSize}");
                    if (estimatedWeight != -1 && estimatedHeight != -1)
                    {
                        int weightDifference = Math.Abs(Weight.Value - estimatedWeight);
                        int heightDifference = Math.Abs(Height.Value - estimatedHeight);

                        int weightTolerance = 20; // Loose Fit = relaxed tolerance
                        int heightTolerance = 20;

                        Console.WriteLine($"🔹 Estimated Weight for {largerSize}: {estimatedWeight} kg |" +
                            $" User Weight: {Weight.Value} kg (Difference: {weightDifference} kg)");
                        Console.WriteLine($"🔹 Estimated Height for {largerSize}: {estimatedHeight} cm | " +
                            $"User Height: {Height.Value} cm (Difference: {heightDifference} cm)");

                        // ✅ If Waist is a perfect match for the next size, allow slightly larger mismatches in Weight/Height
                        bool waistMatchesLargerSize = secondaryMeasurement >= sizeChart[largerSize]["WaistMin"] &&
                                                      secondaryMeasurement <= sizeChart[largerSize]["WaistMax"];

                        if (waistMatchesLargerSize)
                        {
                            Console.WriteLine($"✔️ Waist is a perfect match for {largerSize}. Increasing mismatch tolerance.");
                            weightTolerance += 5;  // Increase tolerance slightly
                            heightTolerance += 5;
                        }

                        if (weightDifference > weightTolerance || heightDifference > heightTolerance)
                        {
                            Console.WriteLine($"❌ Cannot size up! Keeping {recommendedSize} to avoid mismatch.");
                            return recommendedSize;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"✅ Keeping the recommended size: {recommendedSize} (Chest is well in range)");
                        return recommendedSize; // ✅ Keep the original size if not near upper bound
                    }
                }

            }
            // 🚨 If there's no smaller or larger size available, provide a recommendation message
            if (FitPreference == "Tight" && currentIndex == 0)
            {
                if (recommendedSize == availableSizes[currentIndex]) // Only set message if no change occurred
                {
                    RecommendationMessage = $"There is no smaller size available. Recomending size {recommendedSize} as the best fit.";
                    Console.WriteLine($"⚠️ No smaller size available. Keeping {recommendedSize}.");
                }
            }
            else if (FitPreference == "Loose" && currentIndex == availableSizes.Count - 1)
            {
                if (recommendedSize == availableSizes[currentIndex]) // Only set message if no change occurred
                {
                    RecommendationMessage = $"There is no larger size available. Recomending size {recommendedSize} as the best fit.";
                    Console.WriteLine($"⚠️ No larger size available. Keeping {recommendedSize}.");
                }
            }


            return recommendedSize;
        }




        private int GetSizeOrder(string size)
        {
            return size switch
            {
                "S" => 1,   // Small
                "M" => 2,   // Medium
                "L" => 3,   // Large
                "XL" => 4,  // Extra Large

                _ => int.TryParse(size, out int numericSize) ? numericSize + 10 : int.MaxValue
            };
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