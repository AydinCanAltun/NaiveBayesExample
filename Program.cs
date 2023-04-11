using NaiveBayesExample;

List<List<string>> trainingDataset = new List<List<string>>() {
    new List<string> { "genç", "düşük", "en riskli", "Onaylanmaz" },
    new List<string> { "genç", "düşük", "iyi", "Onaylanmaz" },
    new List<string> { "genç", "orta", "orta riskli", "Onaylanmaz" },
    new List<string> { "genç", "yüksek", "çok iyi", "Onaylanmaz" },
    new List<string> { "genç", "yüksek", "iyi", "Onaylanabilir" },
    new List<string> { "genç", "yüksek", "az riskli", "Onaylanabilir"},
    new List<string> { "orta", "düşük", "orta riskli", "Onaylanmaz" },
    new List<string> { "orta", "düşük", "iyi", "Onaylanabilir" },
    new List<string> { "orta", "orta", "orta riskli", "Onaylanabilir" },
    new List<string> { "orta", "orta", "çok iyi", "Onaylanabilir" },
    new List<string> { "orta", "yüksek", "iyi", "Onaylanmaz" },
    new List<string> { "yaşlı", "düşük", "çok iyi", "Onaylanabilir" },
    new List<string> { "yaşlı", "orta", "az riskli", "Onaylanabilir" },
    new List<string> { "yaşlı", "yüksek", "çok iyi", "Onaylanabilir" }
};

NaiveBayes bayes = new NaiveBayes();
bayes.Learn(trainingDataset);
string age = "genç";
string income = "düşük";
string creditScore = "çok iyi";
string result = bayes.Guess(age, income, creditScore);

Console.WriteLine(string.Format("Yaş: {0}, Gelir Düzeyi: {1}, Kredi Skoru: {2} değerlerine göre kredi onaylanır mı ? {3}", age, income, creditScore, result));
Console.ReadKey();
