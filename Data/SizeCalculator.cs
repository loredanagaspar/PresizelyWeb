using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;

namespace PresizelyWeb.Data

{// Represents the Size Calculator entity used for determining the recommended size 
 // based on user inputs and stored size charts.
    public class SizeCalculator
    {
        // Common Measurements

        // Height is a required field, validated to ensure input falls within the realistic range.
        [Required(ErrorMessage = "Height is required for accurate size recommendation.")]
        [Range(140, 230, ErrorMessage = "Height must be between 140 cm and 230 cm.")]
        public int Height { get; set; } // Height in centimeters.

        // Weight is a required field, validated to ensure input falls within the realistic range.
        [Required(ErrorMessage = "Weight is required for accurate size recommendation.")]
        [Range(40, 200, ErrorMessage = "Weight must be between 40 kg and 200 kg.")]
        public int Weight { get; set; } // Weight in kilograms.

        // Tops Measurements (Optional)

        // Bust measurement in centimeters, applicable for tops (optional input).
        public int? Bust { get; set; }

        // Waist measurement in centimeters, applicable for both tops and bottoms (optional input).
        public int? Waist { get; set; }

        // Sleeve length in centimeters, used for certain types of tops like shirts or jackets (optional input).
        public int? SleeveLength { get; set; }

        // Bottoms Measurements (Optional)

        // Waist measurement specific to bottoms, in centimeters (optional input).
        public int? BottomsWaist { get; set; }

        // Hips measurement in centimeters, applicable for bottoms like pants or skirts (optional input).
        public int? Hips { get; set; }

        // Inseam measurement in centimeters, relevant for bottoms like pants or trousers (optional input).
        public int? Inseam { get; set; }

        // Output Properties

        // The recommended size based on the user-provided measurements and size chart data.
        public string RecommendedSize { get; set; }

        // A message providing additional recommendations or feedback to the user about the recommended size.
        public string RecommendationMessage { get; set; }


        /// <summary>
        /// Matches the user's measurements to the closest size from the given size chart.
        /// </summary>
        public string MatchSize(string sizeChartJson, bool isTop)
        {
            var sizeChart = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, int>>>(sizeChartJson);

            if (sizeChart == null || !sizeChart.Any())
            {
                RecommendationMessage = "Invalid or empty size chart data.";
                return "N/A";
            }

            // Validate inputs for out-of-range values
            var warnings = new List<string>();

            if (isTop)
            {
                if (Bust.HasValue && (Bust.Value < 70 || Bust.Value > 140))
                    warnings.Add($"Chest measurement ({Bust.Value} cm) is outside the typical range of 70–140 cm.");
                if (Waist.HasValue && (Waist.Value < 60 || Waist.Value > 150))
                    warnings.Add($"Waist measurement ({Waist.Value} cm) is outside the typical range of 60–150 cm.");
                if (SleeveLength.HasValue && (SleeveLength.Value < 40 || SleeveLength.Value > 70))
                    warnings.Add($"Sleeve length ({SleeveLength.Value} cm) is outside the typical range of 40–70 cm.");
            }
            else
            {
                if (BottomsWaist.HasValue && (BottomsWaist.Value < 60 || BottomsWaist.Value > 150))
                    warnings.Add($"Waist measurement ({BottomsWaist.Value} cm) is outside the typical range of 60–150 cm.");
                if (Hips.HasValue && (Hips.Value < 70 || Hips.Value > 150))
                    warnings.Add($"Hip measurement ({Hips.Value} cm) is outside the typical range of 70–150 cm.");
                if (Inseam.HasValue && (Inseam.Value < 50 || Inseam.Value > 120))
                    warnings.Add($"Inseam measurement ({Inseam.Value} cm) is outside the typical range of 50–120 cm.");
            }

            // If any measurement is outside the range, return N/A with warnings
            if (warnings.Any())
            {
                RecommendationMessage = string.Join(" ", warnings);
                return "N/A";
            }

            // Match size
            var bestMatch = FindBestMatch(sizeChart, isTop);

            if (bestMatch.HasValue)
            {
                RecommendedSize = bestMatch.Value.Key;
                RecommendationMessage = GenerateRecommendationMessage(bestMatch.Value.Value, isTop);
                return RecommendedSize;
            }
            else
            {
                RecommendationMessage = "No suitable size found for the given measurements.";
                return "N/A";
            }
        }



        // Add warnings for missing optional measurements
        private void AddWarningsForMissingMeasurements(bool isTop)
        {
            if (isTop && !SleeveLength.HasValue)
            {
                RecommendationMessage += " Sleeve length was not provided, so the recommendation might not account for sleeve fit.";
            }
            if (!isTop && !Inseam.HasValue)
            {
                RecommendationMessage += " Inseam was not provided, so the recommendation might not account for leg length.";
            }
        }


        /// <summary>
        /// Finds the best matching size from the size chart based on the user's measurements.
        /// </summary>
        /// /// <returns>
        /// The best matching size and its corresponding measurement ranges as a KeyValuePair.
        /// Returns null if no match is found.
        /// </returns>
        /// <remarks>
        /// This method compares each size in the size chart against the user's measurements
        /// to calculate the total difference. The size with the smallest difference is selected
        /// as the best match. Debugging information is logged to the console for each size.
        /// </remarks>
        private KeyValuePair<string, Dictionary<string, int>>? FindBestMatch(
            Dictionary<string, Dictionary<string, int>> sizeChart, bool isTop)
        {
            // Initialize the variables to track the best match and the smallest difference
            KeyValuePair<string, Dictionary<string, int>>? bestMatch = null;
            int smallestDifference = int.MaxValue;

            // Iterate through each size in the size chart
            foreach (var size in sizeChart)
            {
                // Debug log: Display the current size being checked
                Console.WriteLine($"Checking size: {size.Key}");

                // Calculate the total difference for this size based on the user's measurements
                int difference = CalculateDifference(size.Value, isTop);

                // Debug log: Display the calculated difference for the current size
                Console.WriteLine($"Size: {size.Key}, Difference: {difference}");

                // Update the best match if this size has a smaller difference
                if (difference < smallestDifference)
                {
                    smallestDifference = difference; // Update the smallest difference
                    bestMatch = size; // Update the best match to the current size
                }
            }

            // Debug log: Display the best matching size after all sizes are checked
            Console.WriteLine($"Best Match: {bestMatch?.Key}");

            // Return the best match, or null if no match was found
            return bestMatch;
        }


        private int CalculateDifference(Dictionary<string, int> sizeRange, bool isTop)
        {
            int difference = 0;

            if (isTop)
            {
                if (Bust.HasValue)
                    difference += CalculateMetricDifference(Bust.Value, sizeRange["ChestMin"], sizeRange["ChestMax"]);
                if (Waist.HasValue)
                    difference += CalculateMetricDifference(Waist.Value, sizeRange["WaistMin"], sizeRange["WaistMax"]);
                if (SleeveLength.HasValue)
                    difference += CalculateMetricDifference(SleeveLength.Value, sizeRange["SleeveLengthMin"], sizeRange["SleeveLengthMax"]);
            }
            else
            {
                if (BottomsWaist.HasValue)
                    difference += CalculateMetricDifference(BottomsWaist.Value, sizeRange["WaistMin"], sizeRange["WaistMax"]);
                if (Hips.HasValue)
                    difference += CalculateMetricDifference(Hips.Value, sizeRange["HipsMin"], sizeRange["HipsMax"]);
                if (Inseam.HasValue)
                    difference += CalculateMetricDifference(Inseam.Value, sizeRange["InseamMin"], sizeRange["InseamMax"]);
            }

            return difference;
        }


        private int CalculateMetricDifference(int value, int min, int max)
        {
            if (value < min) return min - value;
            if (value > max) return value - max;
            return 0;
        }

        private string GenerateRecommendationMessage(Dictionary<string, int> selectedSize, bool isTop)
        {
            var messages = new List<string>();

            if (isTop)
            {
                if (Bust.HasValue)
                {
                    if (Bust.Value < selectedSize["ChestMin"])
                        messages.Add("Chest might feel tight.");
                    else if (Bust.Value > selectedSize["ChestMax"])
                        messages.Add("Chest might feel loose.");
                    else
                        messages.Add("Chest fits perfectly.");
                }

                if (Waist.HasValue)
                {
                    if (Waist.Value < selectedSize["WaistMin"])
                        messages.Add("Waist might feel tight.");
                    else if (Waist.Value > selectedSize["WaistMax"])
                        messages.Add("Waist might feel loose.");
                    else
                        messages.Add("Waist fits perfectly.");
                }

                if (SleeveLength.HasValue)
                {
                    if (SleeveLength.Value < selectedSize["SleeveLengthMin"])
                        messages.Add("Sleeve length might feel short.");
                    else if (SleeveLength.Value > selectedSize["SleeveLengthMax"])
                        messages.Add("Sleeve length might feel long.");
                    else
                        messages.Add("Sleeve length fits perfectly.");
                }
            }
            else
            {
                if (Waist.HasValue)
                {
                    if (Waist.Value < selectedSize["WaistMin"])
                        messages.Add("Waist might feel tight.");
                    else if (Waist.Value > selectedSize["WaistMax"])
                        messages.Add("Waist might feel loose.");
                    else
                        messages.Add("Waist fits perfectly.");
                }

                if (Hips.HasValue)
                {
                    if (Hips.Value < selectedSize["HipsMin"])
                        messages.Add("Hips might feel tight.");
                    else if (Hips.Value > selectedSize["HipsMax"])
                        messages.Add("Hips might feel loose.");
                    else
                        messages.Add("Hips fit perfectly.");
                }

                if (Inseam.HasValue)
                {
                    if (Inseam.Value < selectedSize["InseamMin"])
                        messages.Add("Inseam might feel short.");
                    else if (Inseam.Value > selectedSize["InseamMax"])
                        messages.Add("Inseam might feel long.");
                    else
                        messages.Add("Inseam fits perfectly.");
                }
            }

            return string.Join(" ", messages);
        }


    }
}
