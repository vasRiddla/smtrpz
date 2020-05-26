import static org.junit.jupiter.api.Assertions.*;

import java.util.Arrays;
import java.util.Random;

import org.junit.jupiter.api.Test;

public class LabaOneTest {
	@Test
	public void testLabaOne()
	{
		LabaOne junit = new LabaOne();
		boolean is = true;
		boolean num;
		int ar[] = { 2, 3, 5, 7, 11, 13, 17, 19 };
		int n = 3;
		n = n/2;
   	 for (int i = 2; i <= ar[n]; i++)
     {      
		 if (ar[n] % i == 0)
 	    	is = false;
 	    }
		is = true;
		num = junit.isPrime(ar[n]);
		assertEquals(is,num);
	}

}
