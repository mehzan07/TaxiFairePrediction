using Microsoft.ML;
using Microsoft.ML.Data;
using TaxiFairePrediction;
 

// step:1. Initialize ML.NET environment
MLContext mlContext = new MLContext();

// step:2. Load training data
IDataView trainData = mlContext.Data.LoadFromTextFile<ModelInput>("taxi-fare-train.csv", separatorChar: ',', hasHeader: true);

// step:3. Add data transformations
var dataProcessPipeline = mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "PaymentTypeEncoded", "PaymentType")
.Append(mlContext.Transforms.Concatenate(outputColumnName: "Features", "PaymentTypeEncoded", "PassengerCount", "TripTime", "TripDistance"));

//step: 4. Add algorithm
var trainer = mlContext.Regression.Trainers.LightGbm(labelColumnName: "FareAmount", featureColumnName: "Features");
var trainingPipeline = dataProcessPipeline.Append(trainer);

// 5. Train model
var model = trainingPipeline.Fit(trainData);

// 6. Evaluate model on test data
IDataView testData = mlContext.Data.LoadFromTextFile<ModelInput>("taxi-fare-test.csv", separatorChar: ',', hasHeader: true);
IDataView predictions = model.Transform(testData);
var metrics = mlContext.Regression.Evaluate(predictions, "FareAmount");
Console.WriteLine($"Model Quality" + $"(RSquared):{metrics.RSquared}");


// step 7. Predict on sample data and print results
var input = new ModelInput
{
    PassengerCount = 2,
    TripDistance = 4,
    TripTime = 1150,
    PaymentType = "CRD"
};
var result = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(model).Predict(input);
Console.WriteLine($"Predicted fare: " + $"{result.FareAmount}");

