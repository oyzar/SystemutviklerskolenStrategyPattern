package strategyconsoleapplication.product;

import strategyconsoleapplication.Customer;
import strategyconsoleapplication.Product;

public interface ProductRecommender {
    Product recommend(Customer customer);
}
