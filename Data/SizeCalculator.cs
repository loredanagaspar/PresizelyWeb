using System.ComponentModel.DataAnnotations;

namespace PresizelyWeb.Data
{
    public class SizeCalculator
    {
        // Common Measurements
        [Required(ErrorMessage = "Height is required.")]
        [Range(50, 250, ErrorMessage = "Height must be between 50 cm and 250 cm.")]
        public int Height { get; set; } // in cm

        [Required(ErrorMessage = "Weight is required.")]
        [Range(10, 300, ErrorMessage = "Weight must be between 10 kg and 300 kg.")]
        public int Weight { get; set; } // in kg

        // Tops Measurements
        [Range(50, 150, ErrorMessage = "Bust circumference must be between 50 cm and 150 cm.")]
        public int? Bust { get; set; } // in cm

        [Range(40, 150, ErrorMessage = "Waist circumference must be between 40 cm and 150 cm.")]
        public int? Waist { get; set; } // in cm

        [Range(40, 120, ErrorMessage = "Sleeve length must be between 40 cm and 120 cm.")]
        public int? SleeveLength { get; set; } // in cm

        // Bottoms Measurements
        [Range(40, 150, ErrorMessage = "Hips circumference must be between 40 cm and 150 cm.")]
        public int? Hips { get; set; } // in cm

        [Range(50, 120, ErrorMessage = "Inseam length must be between 50 cm and 120 cm.")]
        public int? Inseam { get; set; } // in cm

        // Output
        public string RecommendedSize { get; set; } // Calculated size

        // Method to match size based on comma-separated sizes
        public string MatchSize(string sizeChartJson, bool isTop)
        {
            // Deserialize JSON into a dictionary
            var sizeChart = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, int>>>(sizeChartJson);

            if (isTop)
            {
                foreach (var size in sizeChart)
                {
                    if ((Bust >= size.Value["BustMin"] && Bust <= size.Value["BustMax"]) &&
                        (Waist >= size.Value["WaistMin"] && Waist <= size.Value["WaistMax"]) &&
                        (SleeveLength >= size.Value["SleeveMin"] && SleeveLength <= size.Value["SleeveMax"]))
                    {
                        return size.Key; // Return the matching size
                    }
                }
            }
            else
            {
                foreach (var size in sizeChart)
                {
                    if ((Waist >= size.Value["WaistMin"] && Waist <= size.Value["WaistMax"]) &&
                        (Hips >= size.Value["HipsMin"] && Hips <= size.Value["HipsMax"]) &&
                        (Inseam >= size.Value["InseamMin"] && Inseam <= size.Value["InseamMax"]))
                    {
                        return size.Key; // Return the matching size
                    }
                }
            }

            return "Size not available";
        }

    }
}
