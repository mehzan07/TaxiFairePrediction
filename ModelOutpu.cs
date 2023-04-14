using Microsoft.ML.Data;

namespace TaxiFairePrediction
{
    public class ModelOutput 
    {
        [ColumnName("Score")] 
        public float FareAmount; 
    }
}
