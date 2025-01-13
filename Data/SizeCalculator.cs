using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;

namespace PresizelyWeb.Data
{
    public class SizeCalculator
    {
        // Common Measurements
        [Required(ErrorMessage = "Height is required for accurate size recommendation.")]
        [Range(140, 230, ErrorMessage = "Height must be between 140 cm and 230 cm.")]
        public int Height { get; set; } // in cm

        [Required(ErrorMessage = "Weight is required for accurate size recommendation.")]
        [Range(40, 200, ErrorMessage = "Weight must be between 40 kg and 200 kg.")]
        public int Weight { get; set; } // in kg

        // Tops Measurements (Essential and Optional)
       
      
        public int? Bust { get; set; } // in cm (Chest for menswear)


        public int? Waist { get; set; } // in cm

    
        public int? SleeveLength { get; set; } // Optional for tops

        // Bottoms Measurements (Essential and Optional)
   
    
        public int? BottomsWaist { get; set; } // in cm

   
       
        public int? Hips { get; set; } // in cm


        public int? Inseam { get; set; } // Optional for bottoms

        // Output
        public string RecommendedSize { get; set; }
        public string RecommendationMessage { get; set; }

        // Match size based on size chart
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




        private KeyValuePair<string, Dictionary<string, int>>? FindBestMatch(
     Dictionary<string, Dictionary<string, int>> sizeChart, bool isTop)
        {
            KeyValuePair<string, Dictionary<string, int>>? bestMatch = null;
            int smallestDifference = int.MaxValue;

            foreach (var size in sizeChart)
            {
                Console.WriteLine($"Checking size: {size.Key}");
                int difference = CalculateDifference(size.Value, isTop);
                Console.WriteLine($"Size: {size.Key}, Difference: {difference}");

                if (difference < smallestDifference)
                {
                    smallestDifference = difference;
                    bestMatch = size;
                }
            }

            Console.WriteLine($"Best Match: {bestMatch?.Key}");
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
