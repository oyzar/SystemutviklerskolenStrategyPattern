package strategyconsoleapplication.sales;

import strategyconsoleapplication.Customer;
import strategyconsoleapplication.Product;
import strategyconsoleapplication.SalesMode;

public interface SalesEngine {
    Product recommend(SalesMode salesMode, Customer customer);
}
