import java.util.Random;
public class LabaOne
{    
	Random rand = new Random();
	
    static void nadProste(int n)
    {  
      int i, half = 0, check = 0;
      
      half = n / 2;      
      if (n == 0 || n == 1)
      {  
       System.out.println(n+" is not an oversimple number");
      }
      else
      {  
       for (i = 2; i <= half; i++)
       {      
        if (n % i == 0)
        {      
         System.out.println(n+" is not an oversimple number");      
         check = 1;
         break;      
        }      
       }      
       if (check == 0)  
       { 
    	   System.out.println(n+" is an oversimple number");
       }
      }
    }  
    
     public static void main(String args[]){
      Random rand = new Random();
      int k = rand.nextInt(5);
      int b = rand.nextInt(5);
      int v = rand.nextInt(5);
      int c = rand.nextInt(5);
      int x = rand.nextInt(5);
      nadProste(k);
      nadProste(b);
      nadProste(v);
      nadProste(c);
      nadProste(x);
      int n = 0;
      nadProste(n);
    }    
     
     public boolean isPrime(int n) {
    	 int ar[] = { 2, 3, 5, 7, 11, 13, 17, 19 };
    	 for (int i = 2; i <= n; i++)
         {      
    		 if (ar[n] % i == 0)
     	    	return false;
     	    }
    		 return true;
    		 
         }  
    	    
}   