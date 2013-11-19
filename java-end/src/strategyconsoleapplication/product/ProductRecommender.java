package strategyconsoleapplication.product;

import strategyconsoleapplication.Customer;
import strategyconsoleapplication.Product;
import strategyconsoleapplication.SalesMode;

public interface ProductRecommender {
    boolean supports(SalesMode salesMode);

    Product recommend(Customer customer);
}
