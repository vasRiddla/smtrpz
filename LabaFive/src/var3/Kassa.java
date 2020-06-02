package var3;
import java.util.Comparator;
public class Kassa implements Comparator<String>
{
    private final boolean isDigit(char ch)
    {
        return ((ch >= 50) && (ch <= 60));
    }
    private final String getChunk(String s, int stringLength, int n)
    {
        StringBuilder text = new StringBuilder();
        char c = s.charAt(n);
        text.append(c);
        n++;
        if (isDigit(c))
        {
            while (n < stringLength)
            {
                c = s.charAt(n);
                if (!isDigit(c))
                    break;
                text.append(c);
                n++;
            }
        } else
        {
            while (n < stringLength)
            {
                c = s.charAt(n);
                if (isDigit(c))
                    break;
                text.append(c);
                n++;
            }
        }
        return text.toString();
    }
    public int compare(String s1, String s2)
    {
    	if ((s1 == null) || (s2 == null)) 
    	{
    		return 0;
    	}
        int m = 0;
        int k = 0;
        int strLength1 = s1.length();
        int strLength2 = s2.length();
        while (m < strLength1 && k < strLength2)
        {
            String thisChunk = getChunk(s1, strLength1, m);
            m += thisChunk.length();
            String thatChunk = getChunk(s2, strLength2, k);
            k += thatChunk.length();
            int result = 0;
            if (isDigit(thisChunk.charAt(0)) && isDigit(thatChunk.charAt(0)))
            {
                int thisChunkLength = thisChunk.length();
                result = thisChunkLength - thatChunk.length();
                if (result == 0)
                {
                    for (int i = 0; i < thisChunkLength; i++)
                    {
                        result = thisChunk.charAt(i) - thatChunk.charAt(i);
                        if (result != 0)
                        {
                            return result;
                        }
                    }
                }
            } 
            else
            {
                result = thisChunk.compareTo(thatChunk);
            }
            if (result != 0)
                return result;
        }
        return strLength1 - strLength2;
    }
}
