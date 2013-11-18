package strategyconsoleapplication.product;

import strategyconsoleapplication.Customer;
import strategyconsoleapplication.Gender;
import strategyconsoleapplication.Product;

public class LowPriceProductRecommender implements ProductRecommender {
    @Override
    public Product recommend(Customer customer) {
        if (customer.getGender() == Gender.FEMALE) {
            return new Product("Økonomi sko", "Stylish shoes for stylish girls with a budget");
        } else {
            return new Product("Pokal øl", "More beer for men");
        }
    }
}
