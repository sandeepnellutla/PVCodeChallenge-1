using System.Collections.Generic;
using System.Linq;

namespace PVCodeChallenge.BusinessLogic
{
    class BLFactory
    {
        public Dictionary<int, string> GetNumbersForRegister(int minNum, int maxNum)
        {

            var multiplesof3 = Enumerable.Range(1, 100)
                                                        .Where(x => x % 3 == 0)
                                                        .Where(x => x % 5 != 0)
                                                        .ToDictionary(key => key, value => "'Register'");
            var multiplesof5 = Enumerable.Range(1, 100)
                                                    .Where(x => x % 5 == 0)
                                                    .Where(x => x % 3 != 0)
                                                    .ToDictionary(key => key, value => "'Patient'");
            var multiplesofboth = Enumerable.Range(1, 100)
                                                            .Where(x => x % 3 == 0)
                                                            .Where(x => x % 5 == 0)
                                                            .ToDictionary(key => key, value => "'Register'&'Patient'");
            var multiplesofnone = Enumerable.Range(1, 100)
                                                            .Where(x => x % 3 != 0)
                                                            .Where(x => x % 5 != 0)
                                                            .ToDictionary(key => key, value => value.ToString());

            Dictionary<int, string> sortedresults = ((multiplesof3.Concat(multiplesof5)).Concat(multiplesofboth)).Concat(multiplesofnone)
                                                .OrderBy(x => x.Key)
                                                .ToDictionary(x => x.Key, y => y.Value);

            return sortedresults;
        }

        public Dictionary<int, string> GetNumbersForDiagnose(int minNum, int maxNum)
        {

            var multiplesof2 = Enumerable.Range(1, 100)
                                                        .Where(x => x % 2 == 0)
                                                        .Where(x => x % 7 != 0)
                                                        .ToDictionary(key => key, value => "'Diagnose'");
            var multiplesof7 = Enumerable.Range(1, 100)
                                                    .Where(x => x % 7 == 0)
                                                    .Where(x => x % 2 != 0)
                                                    .ToDictionary(key => key, value => "'Patient'");
            var multiplesofboth = Enumerable.Range(1, 100)
                                                            .Where(x => x % 2 == 0)
                                                            .Where(x => x % 7 == 0)
                                                            .ToDictionary(key => key, value => "'Diagnose'&'Patient'");
            var multiplesofnone = Enumerable.Range(1, 100)
                                                            .Where(x => x % 2 != 0)
                                                            .Where(x => x % 7 != 0)
                                                            .ToDictionary(key => key, value => value.ToString());

            Dictionary<int, string> sortedresults = ((multiplesof2.Concat(multiplesof7)).Concat(multiplesofboth)).Concat(multiplesofnone)
                                                .OrderBy(x => x.Key)
                                                .ToDictionary(x => x.Key, y => y.Value);

            return sortedresults;
        }

    }
}
