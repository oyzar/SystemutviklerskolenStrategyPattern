package strategyconsoleapplication.product;

import strategyconsoleapplication.Customer;
import strategyconsoleapplication.Gender;
import strategyconsoleapplication.Product;

public class GenderProductRecommender implements ProductRecommender {
    @Override
    public Product recommend(Customer customer) {
        if (customer.getGender() == Gender.FEMALE) {
            return new Product("Prada purse", "Dream handbag for girls of all ages");
        } else {
            return new Product("Rollex Sea-Dweller", "Real man's watch");
        }
    }
}
