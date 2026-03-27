public class Paperboy {
    
    public void collectPayment(Customer customer, double paymentAmount) {

        boolean paymentSuccessful = customer.payAmount(paymentAmount);
        
        if (paymentSuccessful) {
            System.out.println("Payment received.");
        } else {
            System.out.println("Insufficient balance.");
        }
    }
}

public class Customer {

    private String firstName;
    private String lastName;
    private Wallet myWallet;

    public String getFirstName() {
        return firstName; 
    }

    public String getLastName() {
        return lastName; 
    }

    public boolean payAmount(double amount) {
        if (myWallet.getTotalMoney() >= amount) {
            myWallet.subtractMoney(amount);
            return true;
        }

        return false;
    }
}

public class Wallet {

    private double balance;

    public double getTotalMoney() {
        return balance; 
    }

    public void setTotalMoney(double  newValue) {
        balance = newValue; 
    }

    public void subtractMoney(double  debit) {
        balance -= debit;
    }
}