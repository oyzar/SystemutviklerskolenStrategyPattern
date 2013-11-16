package strategyconsoleapplication.interfaces;

import strategyconsoleapplication.Product;

public interface ProductRecommender {
    Product recommend(Customer customer);
}
