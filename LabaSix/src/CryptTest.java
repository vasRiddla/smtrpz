import javax.crypto.Cipher;

import org.junit.jupiter.api.Test;

import java.io.File;
import java.util.Arrays;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

import static org.junit.jupiter.api.Assertions.*;

class test_Test {
	@Test
	void fileProcessor_test() {
		String key = "12345";
		File in = new File("test.txt");
		File cipher = new File("text.encrypted");
		File decipher = new File("decrypted.txt");
	     test.cipher(Cipher.ENCRYPT_MODE,key,in,cipher);
	     test.cipher(Cipher.DECRYPT_MODE,key,cipher,decipher);
         }
}
