public class OrderProcessor 
{ 
    private readonly IPaymentGateway _paymentGateway; 
    private readonly IInventoryService _inventoryService; 
    private readonly INotificationService _notificationService; 
 
    public OrderProcessor(IPaymentGateway paymentGateway, 
        IInventoryService inventoryService, 
        INotificationService notificationService) 
    { 
        _paymentGateway = paymentGateway; 
        _inventoryService = inventoryService; 
        _notificationService = notificationService; 
    } 
 
    // This method processes an order
    // --> Not needed the function name is self explanatory (Noise)
    public async Task<OrderResult> ProcessOrder(Order order) 
    { 
        // Check if order is null 
        // --> Not needed the code is self explanatory (Redundant)
        if (order == null) 
        { 
            throw new ArgumentNullException(nameof(order)); 
        } 
 
        // Validate the order 
        // --> Not needed the function name is self explanatory (Redundant)
        if (!IsValidOrder(order)) 
        { 
            return OrderResult.Invalid("Order validation failed"); 
        } 
 
        // Check inventory 
        // --> can be misleading as 'check inventory' isn't descriptive enough like check what? whether we have sapce in inventory, or do we even have invetory? The second opinion is code is self explanatory so comment is not required (Misleading)
        bool hasInventory = await _inventoryService.CheckAvailability(order.Items); 
 
        // If no inventory, return failure 
        // -->(Noise)
        if (!hasInventory) 
        { 
            return OrderResult.Failed("Insufficient inventory"); 
        } 
 
        // Reserve inventory 
        // -->(Redundant)
        await _inventoryService.ReserveItems(order.Items); 
 
        try 
        { 
            // Process payment 
            // -->(Redundant)
            var paymentResult = await _paymentGateway.ProcessPayment( 
                order.CustomerId, 
                order.TotalAmount, 
                order.PaymentMethod); 
 
            // Check if payment succeeded 
            // -->(Noise)
            if (paymentResult.IsSuccessful) 
            { 
                // Update inventory -
                // --> redundant
                await _inventoryService.CommitReservation(order.Items); 
 
                // Send confirmation email 
                // -->(Noise)
                await _notificationService.SendOrderConfirmation(order); 
 
                // Return success 
                // -->(Noise)
                return OrderResult.Success(paymentResult.TransactionId); 
            } 
            else 
            { 
                // Payment failed, release inventory 
                // --> Since this is in else part that means it is a faliure case, so no need for explixitly pointing out (Redundant)
                await _inventoryService.ReleaseReservation(order.Items); 
 
                // Return failure 
                // -->(Noise)
                return OrderResult.Failed($"Payment failed: {paymentResult.ErrorMessage}"); 
            } 
        } 
        catch (Exception ex) 
        { 
            // Something went wrong 
            // --> As this block will execute only when there is some error/exception so it can be self understood: (Redundant)
            await _inventoryService.ReleaseReservation(order.Items); 
 
            // Log the error
            // -->(Noise)
            Console.WriteLine($"Error: {ex.Message}"); 
 
            // Throw it 
            // --> Does not add any value or information (Noise)
            throw; 
        } 
    } 
 
    private bool IsValidOrder(Order order) 
    { 
        // TODO: Fix this later 
        // --> No information is provided (Misleading)
        return order.Items?.Count > 0 && order.TotalAmount > 0; 
    } 
 
    // Added by John on 12/15/2023 - needed for the new feature 
    // --> It contains personal details which is not good for codebase: Noise
    public async Task CancelOrder(string orderId) 
    { 
        // Get the order 
        // --> (Redundant)
        var order = await GetOrderById(orderId); 
 
        // John says we need to refund here 
        // --> (Redundant)
        if (order.Status == OrderStatus.Paid) 
        { 
            // Refund the payment 
            // -->(Redundant)
            await _paymentGateway.RefundPayment(order.TransactionId); 
 
            // Give back the items 
            // --> (Redundant)
            await _inventoryService.RestoreInventory(order.Items); 
        } 
 
        // Update status 
        // --> (No comment was required here as code self explain that status is being changes so that means it is updated, so: Redundant)
        order.Status = OrderStatus.Cancelled; 
 
        // This is important!!! 
        // --> (Noise)
        await SaveOrder(order); 
    } 
 
    // Gets order by ID 
    // --> (Noise)
    private async Task<Order> GetOrderById(string orderId) 
    { 
        // Implementation here 
        // --> (Noise)
        return await Task.FromResult(new Order()); 
    } 
 
    // Saves the order 
    // --> (Noise)
    private async Task SaveOrder(Order order) 
    { 
        // Implementation here 
        // --> (Noise)
        await Task.CompletedTask; 
    } 
}