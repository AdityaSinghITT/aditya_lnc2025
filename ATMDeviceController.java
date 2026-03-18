    class DeviceLockedException extends Exception {
        public DeviceLockedException(String message) {
            super(message);
        }
    }

class InsufficientFundsException extends Exception {
    public InsufficientFundsException(String message) {
        super(message);
    }
}

class NetworkConnectionException extends Exception {
    public NetworkConnectionException(String message) {
        super(message);
    }
}

class InvalidDeviceException extends Exception {
    public InvalidDeviceException(String message) {
        super(message);
    }
}

public class ATMDeviceController {

    private static final int DEVICE_SUSPENDED = -1;
    private static final int WIFI_CONNECTED = 1;

    public void withdraw(String accountId, double amount)
            throws DeviceLockedException,
                   InsufficientFundsException,
                   NetworkConnectionException,
                   InvalidDeviceException {

        DeviceHandle handle = getValidHandle();
        DeviceRecord record = getActiveDeviceRecord(handle);

        ensureConnected(record);
        ensureSufficientBalance(accountId, amount);

        dispenseCash(handle, amount);
    }

    private DeviceHandle getValidHandle() throws InvalidDeviceException {
        DeviceHandle handle = getHandle(DEV1);
        if (handle == DeviceHandle.INVALID) {
            throw new InvalidDeviceException("Invalid device handle");
        }
        return handle;
    }

    private DeviceRecord getActiveDeviceRecord(DeviceHandle handle) throws DeviceLockedException {
        DeviceRecord record = retrieveDeviceRecord(handle);
        if (record.getStatus() == DEVICE_SUSPENDED) {
            throw new DeviceLockedException("Device is suspended");
        }
        return record;
    }

    private void ensureConnected(DeviceRecord record) throws NetworkConnectionException {
        if (record.getWifiConnection() != WIFI_CONNECTED) {
            throw new NetworkConnectionException("No network connection");
        }
    }

    private void ensureSufficientBalance(String accountId, double amount)
            throws InsufficientFundsException {
        if (getBalance(accountId) < amount) {
            throw new InsufficientFundsException("Insufficient balance");
        }
    }
}