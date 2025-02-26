namespace KeraNaidi.Services;

public class Utilities
{
    public string GenerateRandomCodes(int numberOfCodes)
    {
        int index = 0;
        string code = string.Empty;
        do{
            code +=  Convert.ToChar(new Random().Next(65, 90));
            code +=  Convert.ToChar(new Random().Next(65, 90));
            code +=  Convert.ToChar(new Random().Next(65, 90));
            
            // Three numbers
            code +=  new Random().Next(0, 9).ToString();
            code +=  new Random().Next(0, 9).ToString();
            code +=  new Random().Next(0, 9).ToString();
            code += "\n";
            index++;

        }while(!(index > numberOfCodes));

        
        return code;
    }
    
}