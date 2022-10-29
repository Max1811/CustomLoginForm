using LoginForm.BL.Parsing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.BL.Algorithms
{
    public class AnalyticHierarchyProcessor : IAlgorithmProcessor
    {
        public List<AlgorithmExecutionResult> Handle(List<Alternative> alternatives, List<Criterion> criterias, List<double> relativeImportanceList)
        {
            var updatedCriterias = CompareCriterias(criterias, relativeImportanceList);

            var updatedAlternatives = CompareAlternatives(alternatives, relativeImportanceList);

            var results = GetAlternativeWeights(updatedCriterias, updatedAlternatives);

            return results;   
        }

        private List<Criterion> CompareCriterias(List<Criterion> criterias, List<double> relativeImportanceList)
        {
            var relativeImportance = new List<double>(relativeImportanceList);

            if (criterias.Count > relativeImportance.Count)
            {
                relativeImportance = RecalculateRelativeImportance(relativeImportance);
            }

            var values = criterias.OrderBy(x => x.Rank).Select(x => x.Rank).ToList();

            var rankScale = GenerateScale(values, relativeImportance);

            var valueEstimates = GetValueEstimatesList(values, relativeImportance, rankScale, SortingDirection.Ascending);

            var weightsList = GetWeightsList(values, valueEstimates);

            criterias = SetWeightForCriterias(weightsList, criterias);


            return criterias;
        }

        private List<Alternative> CompareAlternatives(List<Alternative> alternatives, List<double> relativeImportanceList)
        {
            var relativeImportance = new List<double>(relativeImportanceList);

            if (alternatives.Count > relativeImportance.Count)
            {
                relativeImportance = RecalculateRelativeImportance(relativeImportance);
            }

            int length = alternatives.FirstOrDefault().Criterias.Count;

            for (int i = 0; i < length; i++)
            {
                var sortDesc = alternatives.First().Criterias[i].Sort;

                var values = new List<double>();
                if (sortDesc == SortingDirection.Ascending)
                {
                    values = alternatives.OrderBy(x => x.Criterias[i].Value).Select(x => x.Criterias[i].Value).ToList();
                }
                else
                {
                    values = alternatives.OrderByDescending(x => x.Criterias[i].Value).Select(x => x.Criterias[i].Value).ToList();
                }

                alternatives = alternatives.OrderBy(x => x.Criterias[i].Value).ToList();

                var rankScale = GenerateScale(values, relativeImportance);

                var valueEstimates = GetValueEstimatesList(values, relativeImportance, rankScale, sortDesc);

                var weightsList = GetWeightsList(values, valueEstimates);

                alternatives = SetWeightForAlternatives(weightsList, alternatives, i);
            }


            return alternatives;
        }

        private List<double> RecalculateRelativeImportance(List<double> relativeImportanceList)
        {
            var newValues = new List<double>();

            for (int i = 0; i < relativeImportanceList.Count - 1; i++)
            {
                var first = relativeImportanceList[i];
                var second = relativeImportanceList[i + 1];
                var average = (first + second) / 2;
                newValues.Add(average);
            }

            relativeImportanceList.AddRange(newValues);
            relativeImportanceList.Sort();

            return relativeImportanceList;
        }

        private List<double> GenerateScale(List<double> values, List<double> relativeImportanceList)
        {
            var rankScale = new List<double>();
            var firstValue = values.FirstOrDefault();
            var lastValue = values.LastOrDefault();

            rankScale.Add(firstValue);

            var step = (lastValue - firstValue) / (relativeImportanceList.Count - 1);

            for (int i = 1; i < relativeImportanceList.Count; i++)
            {
                rankScale.Add(firstValue + (step * i));
            }

            return rankScale;
        }

        private List<double> GetValueEstimatesList(List<double> values, List<double> relativeImportanceList, List<double> rankScale, SortingDirection sortDirection)
        {
            var valueEstimates = new List<double>();

            foreach (var value in values)
            {
                var existedIndex = rankScale.FindIndex(x => x == value);
                // need to use here array n x n

                if (existedIndex == -1)
                {
                    var lowerIndex = sortDirection == SortingDirection.Ascending 
                        ? rankScale.FindLastIndex(x => x < value) 
                        : rankScale.FindLastIndex(x => x > value);

                    var upperIndex = sortDirection == SortingDirection.Ascending 
                        ? rankScale.FindIndex(x => x > value) 
                        : rankScale.FindIndex(x => x < value);

                    var lowerModule = Math.Abs(rankScale[lowerIndex] - value);
                    var upperModule = Math.Abs(rankScale[upperIndex] - value);

                    var valueEstimate = lowerModule < upperModule ? relativeImportanceList[lowerIndex] : relativeImportanceList[upperIndex];
                    valueEstimates.Add(valueEstimate);
                }
                else
                {
                    var existedValue = relativeImportanceList[existedIndex];
                    valueEstimates.Add(existedValue);
                }
            }

            return valueEstimates;
        }

        private List<double> GetWeightsList(List<double> values, List<double> valueEstimates)
        {
            int tableLength = values.Count;

            int counter = 0;

            double[,] table = new double[tableLength, tableLength];

            for (int i = 0; i < tableLength; i++)
            {
                for (int j = 0; j < tableLength - i; j++)
                {
                    table[i, j + i] = valueEstimates[j];
                    table[j + i, i] = 1 / valueEstimates[j];
                }

                //recount valuesEstimates
                var lastItem = i == tableLength - 1;
                if (!lastItem)
                {
                    var difference = Math.Abs(valueEstimates[0] - valueEstimates[1]);
                    valueEstimates.RemoveAt(0);
                    valueEstimates = valueEstimates.Select(t => t - difference).ToList();
                }

                counter++;
            }

            var geometricMeanList = GeometricMeanCounter(table);

            var weights = geometricMeanList.Select(x => x / geometricMeanList.Sum()).ToList();

            return weights;
        }

        private List<double> GeometricMeanCounter(double[,] table)
        {
            var geometricMeanList = new List<double>();

            double multiplier = 1;

            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    multiplier *= table[i, j];
                }

                double geometricMean = Math.Pow(multiplier, 1.0 / table.GetLength(0));
                geometricMeanList.Add(geometricMean);
                multiplier = 1;
            }
            return geometricMeanList;
        }

        private List<Criterion> SetWeightForCriterias(List<double> weights, List<Criterion> criterias)
        {
            for (int i = 0; i < criterias.Count; i++)
            {
                criterias[i].Weight = weights[i];
            }

            return criterias;
        }

        private List<Alternative> SetWeightForAlternatives(List<double> weights, List<Alternative> alternatives, int criterionIndex)
        {
            for (int i = 0; i < alternatives.Count; i++)
            {
                alternatives[i].Criterias[criterionIndex].Weight = weights[i];
            }

            return alternatives;
        }

        private List<AlgorithmExecutionResult> GetAlternativeWeights(List<Criterion> criterias, List<Alternative> alternatives)
        {
            var result = new List<AlgorithmExecutionResult>();
            double sum = 0;

            for (int i = 0; i < alternatives.Count; i++)    
            {
                for (int j = 0; j < alternatives[i].Criterias.Count; j++)
                {
                    sum += alternatives[i].Criterias[j].Weight * criterias[j].Weight;
                }

                result.Add(new AlgorithmExecutionResult
                {
                    AlternativeName = alternatives[i].Name,
                    Weight = sum
                });
                sum = 0;
            }

            return result;
        }
    }
}
