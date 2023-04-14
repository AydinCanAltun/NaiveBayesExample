using NaiveBayesExample;

List<List<string>> trainingDataset = new List<List<string>>() {
    new List<string> { "young", "low", "very risky", "Not approved" },
    new List<string> { "young", "low", "good", "Not approved" },
    new List<string> { "young", "middle", "medium risk", "Not approved" },
    new List<string> { "young", "high", "very good", "Not approved" },
    new List<string> { "young", "high", "good", "Approvable" },
    new List<string> { "young", "high", "low risk", "Approvable"},
    new List<string> { "middle age", "low", "medium risk", "Not approved" },
    new List<string> { "middle age", "low", "good", "Approvable" },
    new List<string> { "middle age", "middle", "medium risk", "Approvable" },
    new List<string> { "middle age", "middle", "very good", "Approvable" },
    new List<string> { "middle age", "high", "good", "Not approved" },
    new List<string> { "old", "low", "very good", "Approvable" },
    new List<string> { "old", "middle", "low risk", "Approvable" },
    new List<string> { "old", "high", "very good", "Approvable" }
};

NaiveBayes bayes = new NaiveBayes();
bayes.Train(trainingDataset);
string age = "young";
string income = "high";
string creditScore = "very good";
string result = bayes.Predict(age, income, creditScore);

Console.WriteLine(string.Format("Yaş: {0}, Gelir Düzeyi: {1}, Kredi Skoru: {2} değerlerine göre kredi onaylanır mı ? {3}", age, income, creditScore, result));
Console.ReadKey();
