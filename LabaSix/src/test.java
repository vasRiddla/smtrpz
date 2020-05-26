import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.security.InvalidKeyException;
import java.security.Key;
import java.security.NoSuchAlgorithmException;
import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.spec.SecretKeySpec;

public class test {

   static void cipher(int encrypt, String skey, File in, File out){
	 try {
	       Key key = new SecretKeySpec(skey.getBytes(), "AES");
	       Cipher cipher = Cipher.getInstance("AES");
	       cipher.init(encrypt, key);
	       FileInputStream inputStream = new FileInputStream(in);
	       byte[] inputBytes = new byte[(int) in.length()];
	       inputStream.read(inputBytes);
	       byte[] outputBytes = cipher.doFinal(inputBytes);
	       FileOutputStream outputStream = new FileOutputStream(out);
	       outputStream.write(outputBytes);
	       inputStream.close();
	       outputStream.close();

	    } catch (NoSuchPaddingException | NoSuchAlgorithmException | InvalidKeyException | BadPaddingException| IllegalBlockSizeException | IOException e) {e.printStackTrace();}
     }
}
	


