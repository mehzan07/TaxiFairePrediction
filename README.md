# Taxi Fare PredictionTaxiFairePrediction
In this project you'll see how to use ML.NET to predict taxi fares. In the world of machine learning, this type of prediction is known as regression.

Problem
This problem is centered around predicting the fare of a taxi trip in New York City. At first glance, it may seem to depend simply on the distance traveled. However, taxi vendors in New York charge varying amounts for other factors such as additional passengers, paying with a credit card instead of cash and so on. This prediction can be used in application for taxi providers to give users and drivers an estimate on ride fares.

To solve this problem, we will build an ML model that takes as inputs:

vendor ID
rate code
passenger count
trip time
trip distance
payment type
and predicts the fare of the ride.

ML task - Regression
The generalized problem of regression is to predict some continuous value for given parameters, for example:

predict a house price based on number of rooms, location, year built, etc.
predict a car fuel consumption based on fuel type and car parameters.
predict a time estimate for fixing an issue based on issue attributes.
The common feature for all above is that the parameter we want to predict can take any numeric value in certain range. 
In other words, this value is represented by integer or float/double, not by enum or boolean types.

Solution
To solve this problem, first we will build an ML model. Then we will train the model on existing data, evaluate how good it is, and lastly we'll consume the model to predict taxi fares.
