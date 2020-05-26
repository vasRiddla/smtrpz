package var3;

import org.junit.jupiter.api.Test;

import java.util.Arrays;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

import static org.junit.jupiter.api.Assertions.*;

class Kassa_Test {

    @Test
    void compare_Test() {
    	List<String> values = Arrays.asList("Oranges(x2)", "Apples", "Oranges(x300)", "Watermelon", "Pomegranate", "Watermelons (x2)", "Carrot", "Oranges(x7)", "Kiwi", "Carrot(x4)", "Banana");
    	System.out.println(values.stream().sorted(new Kassa()).collect(Collectors.joining(" " + "\n")));

    }
}