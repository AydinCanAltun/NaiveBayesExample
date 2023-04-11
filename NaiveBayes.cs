using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveBayesExample {
    public class NaiveBayes {
        private static readonly List<string> AGE_VALUES = new List<string> { "genç", "orta", "yaşlı" };
        private static readonly List<string> INCOME_VALUES = new List<string> { "düşük", "orta", "yüksek" };
        private static readonly List<string> CREDIT_SCORE_VALUES = new List<string> { "en riskli", "orta riskli", "az riskli", "iyi", "çok iyi" };

        private Dictionary<string, Dictionary<string, double>> agePosibilities = new Dictionary<string, Dictionary<string, double>>();
        private Dictionary<string, Dictionary<string, double>> incomePosibitilies = new Dictionary<string, Dictionary<string, double>>();
        private Dictionary<string, Dictionary<string, double>> creditScorePosibilities = new Dictionary<string, Dictionary<string, double>>();

        private Dictionary<string, int> outcomeCount = new Dictionary<string, int>();

        private Dictionary<string, double> outcomePosibilities = new Dictionary<string, double>();

        public void Learn(List<List<string>> trainingData) {
            int totalTrainingDataLength = trainingData.Count;

            for (int i = 0; i < totalTrainingDataLength; i++) {
                List<string> data = trainingData[i];
                string outcome = data.Last();

                if (!outcomeCount.ContainsKey(outcome)) {
                    outcomeCount[outcome] = 0;
                }
                outcomeCount[outcome]++;
            }

            foreach (string sinif in outcomeCount.Keys) {
                outcomePosibilities[sinif] = (double)outcomeCount[sinif] / totalTrainingDataLength;
            }

            agePosibilities = CreatePosibilityTable(trainingData, 0, AGE_VALUES);
            incomePosibitilies = CreatePosibilityTable(trainingData, 1, INCOME_VALUES);
            creditScorePosibilities = CreatePosibilityTable(trainingData, 2, CREDIT_SCORE_VALUES);
        }

        public string Guess(string age, string income, string creditScore) {
            Dictionary<string, double> caseOutcomePosibilities = new Dictionary<string, double>();
            foreach (string outcome in outcomePosibilities.Keys) {
                double outcomePosibility = outcomePosibilities[outcome];

                double agePosibility = agePosibilities[outcome][age];
                outcomePosibility *= agePosibility;

                double incomePosibility = incomePosibitilies[outcome][income];
                outcomePosibility *= incomePosibility;

                double creditRiskScorePosibility = creditScorePosibilities[outcome][creditScore];
                outcomePosibility *= creditRiskScorePosibility;

                caseOutcomePosibilities[outcome] = outcomePosibility;
            }

            return caseOutcomePosibilities.OrderByDescending(x => x.Value).First().Key;
        }

        private Dictionary<string, Dictionary<string, double>> CreatePosibilityTable(List<List<string>> traniningData, int propertyIndex, List<string> values) {
            Dictionary<string, Dictionary<string, double>> posibilityTable = new Dictionary<string, Dictionary<string, double>>();

            foreach (string outcome in outcomePosibilities.Keys) {
                Dictionary<string, int> posibleValueCount = new Dictionary<string, int>();

                foreach (string value in values) {
                    posibleValueCount[value] = 0;
                }

                foreach (List<string> data in traniningData) {
                    if (data.Last() != outcome) {
                        continue;
                    }
                    posibleValueCount[data[propertyIndex]]++;
                }

                Dictionary<string, double> valuePosibilities = new Dictionary<string, double>();
                int totalOutcomeLength = outcomeCount[outcome];

                foreach (string posibleValue in posibleValueCount.Keys) {
                    double posibility = (double)posibleValueCount[posibleValue] / totalOutcomeLength;
                    valuePosibilities[posibleValue] = posibility;
                }

                posibilityTable[outcome] = valuePosibilities;
            }

            return posibilityTable;
        }

    }
}
