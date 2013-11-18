package strategyconsoleapplication.product;

import strategyconsoleapplication.Customer;
import strategyconsoleapplication.Gender;
import strategyconsoleapplication.Product;

public class SeasonalProductRecommender implements ProductRecommender {
    @Override
    public Product recommend(Customer customer) {
        if (customer.getGender() == Gender.FEMALE) {
            return new Product("Vinterkjole", "Dream winter dress for girls of all age");
        } else {
            return new Product("Vinter sykkeldrakt", "For real cyclists");
        }
    }
}
