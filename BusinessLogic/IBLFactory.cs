using System.Collections.Generic;

namespace PVCodeChallenge.BusinessLogic
{
    public interface IBLFactory
    {
        Dictionary<int, string> GetNumbersForRegisterIMWithInterface(int minNum, int maxNum);
        Dictionary<int, string> GetNumbersForDiagnoseIMWithInterface(int minNum, int maxNum);

    }
}
