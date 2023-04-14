using Microsoft.ML.Data;

namespace TaxiFairePrediction
{
        public class ModelInput
        {
            [LoadColumn(2)]
            public float PassengerCount;
            [LoadColumn(3)]
            public float TripTime;
            [LoadColumn(4)]
            public float TripDistance;
            [LoadColumn(5)]
            public string PaymentType;
            [LoadColumn(6)]
            public float FareAmount;
        }

    }
