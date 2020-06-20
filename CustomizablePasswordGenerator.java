import java.security.SecureRandom;
import java.util.Random;
import java.util.Scanner;

public class CustomizablePasswordGenerator {

    private static void validateInput(int min_len, int max_len, int numberOfDigits, int numberOfSpecialChars) {
        if (max_len < min_len)
            throw  new IllegalArgumentException("Minimum length cannot be bigger than max length!");

        if (numberOfDigits+ numberOfSpecialChars > max_len)
            throw new IllegalArgumentException("Sum of digit and symbol numbers cannot be bigger than max length");

    }

    public static String generatePassword(int min_len, int max_len ,int numberOfDigits, int numberOfSpecialChars) {

        final char[] lowercase = "abcdefghijklmnopqrstuvwxyz".toCharArray();
        final char[] uppercase = "ABCDEFGJKLMNPRSTUVWXYZ".toCharArray();
        final char[] numbers = "0123456789".toCharArray();
        final char[] symbols = "^$?!@#%&".toCharArray();
        final char[] allAllowed = "abcdefghijklmnopqrstuvwxyzABCDEFGJKLMNPRSTUVWXYZ0123456789^$?!@#%&".toCharArray();

        Random random = new SecureRandom();
        StringBuilder password = new StringBuilder();
        for (int i = 0; i < numberOfDigits; i++) {
            password.insert(random.nextInt(password.length()+1), numbers[random.nextInt(numbers.length)]);
        }
        for (int i = 0; i < numberOfSpecialChars; i++) {
            password.insert(random.nextInt(password.length()+1), symbols[random.nextInt(symbols.length)]);
        }
       int randomLength = max_len;
       if (max_len- min_len > 0){
           randomLength = random.nextInt(max_len-min_len+1) +min_len;
       }
       int remainingLength = randomLength - numberOfDigits - numberOfSpecialChars;
        for (int i = 0; i < remainingLength; i++) {
            password.insert(random.nextInt(password.length()+1), allAllowed[random.nextInt(allAllowed.length)]);
        }

        return password.toString();

    }

}



