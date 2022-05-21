/// <summary>
/// <author>Branium Academy</author>
/// <version>2022.05.20</version>
/// <see cref="Trang chủ" href="https://braniumacademy.net"/>
/// </summary>

using System;
using System.Text;

namespace ExercisesLesson610
{
    class Exercises2
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            BankAccount[] bankAccounts = new BankAccount[100];
            int numOfAccount = 0;
            CreateFakeAccount(bankAccounts, ref numOfAccount);
            int choice;
            do
            {
                Console.WriteLine("================== CÁC CHỨC NĂNG ==================");
                Console.WriteLine("1. Thêm mới nhân viên vào danh sách.");
                Console.WriteLine("2. Hiển thị danh sách nhân viên ra màn hình.");
                Console.WriteLine("3. Tính lương các nhân viên trong danh sách.");
                Console.WriteLine("4. Sắp xếp danh sách nhân viên theo lương thực lĩnh.");
                Console.WriteLine("5. Sắp xếp danh sách nhân viên theo số ngày đi làm.");
                Console.WriteLine("6. Tìm và hiển thị thông tin nhân viên theo mã NV.");
                Console.WriteLine("7. Cập nhật lương cho nhân viên theo mã cho trước.");
                Console.WriteLine("8. Xóa bỏ nhân viên khi biết mã NV cho trước.");
                Console.WriteLine("9. Thoát chương trình.");
                Console.WriteLine("==> Xin mời bạn chọn chức năng: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        if (numOfAccount > 0)
                        {
                            ShowAccounts(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 3:
                        if (numOfAccount > 0)
                        {
                            SortAccounts(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 4:
                        if (numOfAccount > 0)
                        {
                            Deposit(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 5:
                        if (numOfAccount > 0)
                        {
                            CheckBallance(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 6:
                        if (numOfAccount > 0)
                        {
                            Withdraw(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 7:
                        if (numOfAccount > 0)
                        {
                            WithdrawOtherBank(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 8:
                        if (numOfAccount > 0)
                        {
                            TransferSameBank(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 9:
                        if (numOfAccount > 0)
                        {
                            TransferDifferentBank(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 10:
                        if (numOfAccount > 0)
                        {
                            PayService(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 11:
                        if (numOfAccount > 0)
                        {
                            CalculateInterest(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 12:
                        Console.WriteLine("==> Cảm ơn quý khách đã sử dụng dịch vụ! <==");
                        break;
                    default:
                        Console.WriteLine("==> Sai chức năng. Vui lòng chọn lại! <==");
                        break;
                }
            } while (choice != 12);
        }

        // tính tiền lãi cuối kỳ của từng tài khoản, cộng gộp vào tk gốc
        private static void CalculateInterest(BankAccount[] bankAccounts)
        {
            for (int i = 0; i < bankAccounts.Length; i++)
            {
                if (bankAccounts[i] == null)
                {
                    break;
                }
                var acc = bankAccounts[i];
                var amount = acc.CalculateInterest();
                acc.Deposit(amount, acc.Bank);
            }
        }

        private static void PayService(BankAccount[] bankAccounts)
        {
            throw new NotImplementedException();
        }

        private static void TransferDifferentBank(BankAccount[] bankAccounts)
        {
            Console.WriteLine("Số tài khoản nguồn: ");
            var accNumber = Console.ReadLine();
            var acc = FindAccountByAccNumber(bankAccounts, accNumber);
            Console.WriteLine("Số tài khoản đích: ");
            var destAccNumber = Console.ReadLine();
            var destAcc = FindAccountByAccNumber(bankAccounts, destAccNumber);
            if (acc != null && destAcc != null)
            {
                Console.WriteLine("Số tiền muốn chuyển: ");
                var amount = long.Parse(Console.ReadLine());
                Console.WriteLine("Ngân hàng thực hiện: ");
                Console.WriteLine("Ngân hàng thực hiện: ");
                var bank = Console.ReadLine();
                var result = acc.BankTransfer(destAcc, amount, bank);
                if (result > 0)
                {
                    Console.WriteLine("==> Chuyển tiền thành công. <==");
                }
                else
                {
                    Console.WriteLine("==> Chuyển tiền thất bại. <==");
                }
            }
            else
            {
                Console.WriteLine("==> Tài khoản nguồn hoặc tài khoản đích không tồn tại. <==");
            }
        }

        private static void TransferSameBank(BankAccount[] bankAccounts)
        {
            Console.WriteLine("Số tài khoản nguồn: ");
            var accNumber = Console.ReadLine();
            var acc = FindAccountByAccNumber(bankAccounts, accNumber);
            Console.WriteLine("Số tài khoản đích: ");
            var destAccNumber = Console.ReadLine();
            var destAcc = FindAccountByAccNumber(bankAccounts, destAccNumber);
            if (acc != null && destAcc != null)
            {
                Console.WriteLine("Số tiền muốn chuyển: ");
                var amount = long.Parse(Console.ReadLine());
                var result = acc.BankTransfer(destAcc, amount, acc.Bank);
                if (result > 0)
                {
                    Console.WriteLine("==> Chuyển tiền thành công. <==");
                }
                else
                {
                    Console.WriteLine("==> Chuyển tiền thất bại. <==");
                }
            }
            else
            {
                Console.WriteLine("==> Tài khoản nguồn hoặc tài khoản đích không tồn tại. <==");
            }
        }

        private static void WithdrawOtherBank(BankAccount[] bankAccounts)
        {
            Console.WriteLine("Số tài khoản: ");
            var accNumber = Console.ReadLine();
            var acc = FindAccountByAccNumber(bankAccounts, accNumber);
            if (acc != null)
            {
                Console.WriteLine("Số tiền muốn rút: ");
                var amount = long.Parse(Console.ReadLine());
                Console.WriteLine("Ngân hàng thực hiện: ");
                var bank = Console.ReadLine();
                var result = acc.Withdraw(amount, bank);
                if (result > 0)
                {
                    Console.WriteLine("==> Rút tiền thành công. <==");
                }
                else
                {
                    Console.WriteLine("==> Rút tiền thất bại. <==");
                }
            }
            else
            {
                Console.WriteLine("==> Tài khoản cần tìm không tồn tại. <==");
            }
        }

        private static void Withdraw(BankAccount[] bankAccounts)
        {
            Console.WriteLine("Số tài khoản: ");
            var accNumber = Console.ReadLine();
            var acc = FindAccountByAccNumber(bankAccounts, accNumber);
            if (acc != null)
            {
                Console.WriteLine("Số tiền muốn rút: ");
                var amount = long.Parse(Console.ReadLine());
                var result = acc.Withdraw(amount, acc.Bank);
                if (result > 0)
                {
                    Console.WriteLine("==> Rút tiền thành công. <==");
                }
                else
                {
                    Console.WriteLine("==> Rút tiền thất bại. <==");
                }
            }
            else
            {
                Console.WriteLine("==> Tài khoản cần tìm không tồn tại. <==");
            }
        }

        private static void CheckBallance(BankAccount[] bankAccounts)
        {
            Console.WriteLine("Số tài khoản: ");
            var accNumber = Console.ReadLine();
            var acc = FindAccountByAccNumber(bankAccounts, accNumber);
            Console.WriteLine("Ngân hàng thực hiện: ");
            var bankName = Console.ReadLine();
            if (acc != null)
            {
                acc.CheckBallance(bankName);
            }
            else
            {
                Console.WriteLine("==> Tài khoản cần tìm không tồn tại. <==");
            }
        }

        public static BankAccount FindAccountByAccNumber(BankAccount[] accounts, string accNumber)
        {
            foreach (var item in accounts)
            {
                if (item != null && item.AccountNumber.CompareTo(accNumber) == 0)
                {
                    return item;
                }
            }
            return null;
        }

        private static void Deposit(BankAccount[] bankAccounts)
        {
            Console.WriteLine("Số tài khoản: ");
            var accNumber = Console.ReadLine();
            var acc = FindAccountByAccNumber(bankAccounts, accNumber);
            if (acc != null)
            {
                Console.WriteLine("Tên ngân hàng làm dịch vụ: ");
                var bank = Console.ReadLine();
                Console.WriteLine("Số tiền cần gửi vào TK: ");
                var amount = long.Parse(Console.ReadLine());
                var result = acc.Deposit(amount, bank);
                if (result > 0)
                {
                    Console.WriteLine("==> Giao dịch thành công. <==");
                }
            }
            else
            {
                Console.WriteLine("==> Tài khoản cần tìm không tồn tại. <==");
            }
        }

        private static void SortAccounts(BankAccount[] bankAccounts)
        {
            int comparer(BankAccount a, BankAccount b)
            {
                if (a == null && b == null)
                {
                    return 0;
                }
                else if (a != null && b == null)
                {
                    return -1;
                }
                else if (a == null || b != null)
                {
                    return 1;
                }
                else
                {
                    if (a.Balance > b.Balance)
                    {
                        return -1;
                    }
                    else if (a.Balance < b.Balance)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            Array.Sort(bankAccounts, comparer);
        }

        private static void ShowAccounts(BankAccount[] bankAccounts)
        {
            var accNumber = "Số tài khoản";
            var owner = "Chủ tài khoản";
            var bank = "Ngân hàng";
            var releaseDate = "Ngày phát hành";
            var balance = "Số dư";
            var interestRate = "Lãi suất";
            var limit = "Hạn mức";
            var term = "Kỳ hạn";
            var start = "Ngày gửi";
            var end = "Ngày hết hạn";
            var interest = "Tiền lãi";
            Console.WriteLine($"{accNumber,-20:d}{owner,-25:d}{bank,-15:d}{releaseDate,-15:d}" +
                $"{balance,-20:d}{interestRate,-15:d}{limit,-20:d}{term,-15:d}{start,-15:d}" +
                $"{end,-15:d}{interest,-20:d}");
            var noData = "-";
            var noTerm = "Không kỳ hạn";
            var format = "dd/MM/yyyy";
            foreach (var item in bankAccounts)
            {
                if (item == null)
                {
                    break;
                }
                if (item.GetType() == typeof(CheckingAccount))
                {
                    var acc = item as CheckingAccount;
                    Console.WriteLine($"{acc.AccountNumber,-20:d}{acc.Owner,-25:d}{acc.Bank,-15:d}" +
                        $"{acc.ReleaseDate,-15:d}{acc.Balance,-20:n}{acc.InterestRate / 100,-15:p}" +
                        $"{acc.PaymentLimit,-20:n}{noTerm,-15:d}{noData,-15:d}" +
                        $"{noData,-15:d}{acc.CalculateInterest(),-20:n}");
                }
                else if (item.GetType() == typeof(SavingAccount))
                {
                    var acc = item as SavingAccount;
                    Console.WriteLine($"{acc.AccountNumber,-20:d}{acc.Owner,-25:d}{acc.Bank,-15:d}" +
                        $"{acc.ReleaseDate,-15:d}{acc.Balance,-20:n}{acc.InterestRate / 100,-15:p}" +
                        $"{noData,-20:d}{acc.Term,-15:d}{acc.StartDate.ToString(format),-15:d}" +
                        $"{acc.EndDate.ToString(format),-15:d}{acc.CalculateInterest(),-20:n}");
                }
            }
        }

        private static void CreateFakeAccount(BankAccount[] bankAccounts, ref int numOfAccount)
        {
            var dateFormatter = "dd/MM/yyyy";
            bankAccounts[numOfAccount++] = new CheckingAccount("0021000435680", "TRAN VAN NAM",
                "Vietcombank", "05/22", 100000000, 1000000000);
            bankAccounts[numOfAccount++] = new CheckingAccount("0021000435681", "LE TAN TAI",
                "Vietcombank", "06/22", 120000000, 1000000000);
            bankAccounts[numOfAccount++] = new CheckingAccount("0021000435682", "NGUYEN BICH HOA",
                "Vietcombank", "07/22", 180000000, 500000000);
            bankAccounts[numOfAccount++] = new CheckingAccount("0021000435683", "HO HAI DANG",
                "Vietcombank", "08/22", 160000000, 500000000);
            bankAccounts[numOfAccount++] = new CheckingAccount("0021000435685", "MAI TUAN NGOC",
                "Vietcombank", "09/22", 15000000, 900000000);
            bankAccounts[numOfAccount++] = new SavingAccount("0021000435686", "LUU TRIEU VI",
                "Vietcombank", "10/22", 1950000000, 12, DateTime.ParseExact("15/10/2022", dateFormatter, null),
                DateTime.ParseExact("15/10/2023", dateFormatter, null));
            bankAccounts[numOfAccount++] = new SavingAccount("0021000435688", "LE VAN CONG",
                "Vietcombank", "09/22", 1500000000, 18, DateTime.ParseExact("10/06/2022", dateFormatter, null),
                DateTime.ParseExact("10/12/2023", dateFormatter, null));
        }
    }

    abstract class BankAccount
    {
        public string AccountNumber { get; set; }
        public string Owner { get; set; }
        public string Bank { get; set; }
        public string ReleaseDate { get; set; }
        public long Balance { get; set; }
        public double InterestRate { get; set; }

        public BankAccount() { }

        public BankAccount(string accNum)
        {
            AccountNumber = accNum;
        }

        public BankAccount(string accNum, string owner, string bank,
            string releaseDate, long balance, double interestRate) : this(accNum)
        {
            AccountNumber = accNum;
            Owner = owner;
            Bank = bank;
            ReleaseDate = releaseDate;
            Balance = balance;
            InterestRate = interestRate;
        }

        // phương thức kiểm tra số dư
        public abstract void CheckBallance(string bankName);
        // phương thức rút tiền
        public abstract long Withdraw(long amount, string bankName);
        // phương thức nạp tiền
        public abstract long Deposit(long amount, string bankName);
        // thanh toán
        public abstract long BankTransfer(BankAccount other, long amount, string bankName);
        // thanh toán hóa đơn, dịch vụ
        public abstract long Pay(BankAccount target, long amount, string bankName);
        // tính tiền lãi cuối kỳ
        public abstract long CalculateInterest();
    }

    class CheckingAccount : BankAccount
    {
        public long PaymentLimit { get; set; }
        public long TotalPayment { get; set; } // tổng tiền thanh toán, rút, chuyển

        public CheckingAccount() { }

        public CheckingAccount(string bankAcc) : base(bankAcc) { }

        public CheckingAccount(string accNum, string owner, string bank,
            string releaseDate, long balance, long limit) :
            base(accNum, owner, bank, releaseDate, balance, 1)
        {
            PaymentLimit = limit;
            TotalPayment = 0;
        }

        public override long CalculateInterest()
        {
            var amount = (long)(InterestRate / 100 * Balance);
            return amount;
        }

        private bool IsPaymentLimitOver(long amount)
        {
            if (amount + TotalPayment > PaymentLimit)
            {
                return true;
            }
            return false;
        }

        public override long BankTransfer(BankAccount other, long amount, string bankName)
        {
            if (other == null)
            {
                Console.WriteLine("==> Tài khoản đích không tồn tại. <==");
                return -1;
            }
            else
            {
                if (amount <= Balance - 50000 && !IsPaymentLimitOver(amount))
                {
                    TotalPayment += amount;
                    Balance -= amount;
                    other.Balance += amount;
                    var fee = 0;
                    if (bankName != null)
                    {
                        // chuyển tiền trên app
                        fee = 1100;
                        if (bankName.CompareTo(Bank) != 0) // chuyển tiền tại ATM
                        {
                            fee = 3300;
                        }
                    }
                    Balance -= fee;
                    Console.WriteLine("==> Chuyển tiền thành công. <==");
                    return amount;
                }
                else if (IsPaymentLimitOver(amount))
                {
                    Console.WriteLine("==> Bạn đã vượt hạn mức thanh toán trong ngày. <==");
                    Console.WriteLine("==> Số tiền có thể chuyển: " + (PaymentLimit - TotalPayment));
                    return -1;
                }
                else
                {
                    Console.WriteLine("==> Số dư không đủ. Chuyển tiền thất bại. <==");
                    return -1;
                }
            }
        }

        public override void CheckBallance(string bankName)
        {
            var dateTimeFormat = "dd/MM/yyyy HH:mm:ss";
            Console.WriteLine("========== THÔNG TIN TÀI KHOẢN ==========");
            Console.WriteLine($"Số tài khoản: {AccountNumber}");
            Console.WriteLine($"Loại tài khoản: Thanh toán");
            Console.WriteLine($"Số dư: {Balance}");
            Console.WriteLine($"Ngày phát hành: {ReleaseDate}");
            Console.WriteLine($"Thời gian thực hiện: {DateTime.Now.ToString(dateTimeFormat)}");
            Console.WriteLine("=========================================");
        }

        public override long Deposit(long amount, string bankName)
        {
            if (amount < 0)
            {
                Console.WriteLine("==> Số tiền cần nạp không hợp lệ. <==");
                return -1;
            }
            else
            {
                Balance += amount;
                Console.WriteLine("==> Nạp tiền thành công. <==");
                var fee = 0;
                if (bankName.CompareTo(Bank) != 0)
                {
                    fee = 35000;
                }
                Console.WriteLine($"==> Phí dịch vụ: {fee}đ");
                return amount;
            }
        }

        public override long Pay(BankAccount target, long amount, string bankName)
        {
            if (target == null)
            {
                Console.WriteLine("==> Tài khoản đích không tồn tại. <==");
                return -1;
            }
            else
            {
                if (amount <= Balance - 50000 && !IsPaymentLimitOver(amount))
                {
                    TotalPayment += amount;
                    Balance -= amount;
                    target.Balance += amount;
                    var fee = 0;
                    if (bankName != null)
                    {
                        // thanh toán trên app
                        fee = 1100;
                        if (bankName.CompareTo(Bank) != 0) // thanh toán tại ATM
                        {
                            fee = 3300;
                        }
                    }
                    Balance -= fee;
                    Console.WriteLine("==> Thanh toán thành công. <==");
                    return amount;
                }
                else if (IsPaymentLimitOver(amount))
                {
                    Console.WriteLine("==> Bạn đã vượt hạn mức thanh toán trong ngày. <==");
                    Console.WriteLine("==> Số tiền có thể chuyển: " + (PaymentLimit - TotalPayment));
                    return -1;
                }
                else
                {
                    Console.WriteLine("==> Số dư không đủ. Thanh toán thất bại. <==");
                    return -1;
                }
            }
        }

        public override long Withdraw(long amount, string bankName)
        {
            if (amount <= Balance - 50000 && !IsPaymentLimitOver(amount))
            {
                TotalPayment += amount;
                var fee = 1100;
                if (bankName.CompareTo(Bank) != 0)
                {
                    fee = 3300;
                }
                Balance = Balance - amount - fee;
                var dateTimeFormat = "dd/MM/yyyy HH:mm:ss";
                Console.WriteLine("==> Rút tiền thành công");
                Console.WriteLine($"==> Thời gian giao dịch: {DateTime.Now.ToString(dateTimeFormat)}");
                return amount + fee;
            }
            else if (IsPaymentLimitOver(amount))
            {
                Console.WriteLine("==> Bạn đã vượt hạn mức thanh toán trong ngày. <==");
                Console.WriteLine("==> Số tiền có thể chuyển: " + (PaymentLimit - TotalPayment));
                return -1;
            }
            else
            {
                Console.WriteLine("==> Số dư của bạn không đủ để thực hiện giao dịch này. <==");
                return -1;
            }
        }
    }

    class SavingAccount : BankAccount
    {
        public int Term { get; set; } // kì hạn
        public DateTime StartDate { get; set; } // ngày gửi
        public DateTime EndDate { get; set; } // ngày đáo hạn
        public long Interest { get; set; } // tiền lãi

        public SavingAccount() { }

        public SavingAccount(string accNum) : base(accNum) { }

        public SavingAccount(string accNum, string owner, string bank,
            string releaseDate, long balance, int term, DateTime start, DateTime end) :
            base(accNum, owner, bank, releaseDate, balance, 0)
        {
            Term = term;
            StartDate = start;
            EndDate = end;
            SetInterestRate();
        }

        public void SetInterestRate()
        {
            switch (Term)
            {
                case -1:
                    InterestRate = 3.0;
                    break;
                case 1:
                    InterestRate = 3.5;
                    break;
                case 3:
                    InterestRate = 4.5;
                    break;
                case 6:
                    InterestRate = 5;
                    break;
                case 12:
                    InterestRate = 5.5;
                    break;
                case 18:
                    InterestRate = 6;
                    break;
                case 24:
                    InterestRate = 6.5;
                    break;
                default:
                    InterestRate = 0;
                    break;
            }
        }

        public override long CalculateInterest()
        {
            Interest = (long)(InterestRate / 100 * Balance);
            return Interest;
        }

        public override long BankTransfer(BankAccount other, long amount, string bankName)
        {
            if (other == null)
            {
                Console.WriteLine("==> Tài khoản đích không tồn tại. <==");
                return -1;
            }
            else
            {
                if (amount <= Balance - 50000)
                {
                    Balance -= amount;
                    other.Balance += amount;
                    var fee = 0;
                    if (bankName != null)
                    {
                        // chuyển tiền trên app
                        fee = 1100;
                        if (bankName.CompareTo(Bank) != 0) // chuyển tiền tại ATM
                        {
                            fee = 3300;
                        }
                    }
                    fee += (int)(3.0 / 100 * amount);
                    Balance -= fee;
                    Console.WriteLine("==> Chuyển tiền thành công. <==");
                    return amount;
                }
                else
                {
                    Console.WriteLine("==> Số dư không đủ. Chuyển tiền thất bại. <==");
                    return -1;
                }
            }
        }

        public override void CheckBallance(string bankName)
        {
            var format = "dd/MM/yyyy";
            var dateTimeFormat = "dd/MM/yyyy HH:mm:ss";
            Console.WriteLine("========== THÔNG TIN TÀI KHOẢN ==========");
            Console.WriteLine($"Số tài khoản: {AccountNumber}");
            Console.WriteLine($"Loại tài khoản: Tiết kiệm");
            Console.WriteLine($"Số dư: {Balance}");
            Console.WriteLine($"Ngày phát hành: {ReleaseDate}");
            Console.WriteLine($"Kỳ hạn: {Term}");
            Console.WriteLine($"Lãi suất: {InterestRate}%");
            Console.WriteLine($"Hiệu lực từ: {StartDate.ToString(format)}");
            Console.WriteLine($"Hiệu lực đến: {EndDate.ToString(format)}");
            Console.WriteLine($"Thời gian thực hiện: {DateTime.Now.ToString(dateTimeFormat)}");
            Console.WriteLine("=========================================");
        }

        public override long Deposit(long amount, string bankName)
        {
            if (amount < 0)
            {
                Console.WriteLine("==> Số tiền cần nạp không hợp lệ. <==");
                return -1;
            }
            else
            {
                Balance += amount;
                Console.WriteLine("==> Nạp tiền thành công. <==");
                var fee = 0;
                if (bankName.CompareTo(Bank) != 0)
                {
                    fee = 35000;
                }
                Console.WriteLine($"==> Phí dịch vụ: {fee}đ");
                return amount;
            }
        }

        public override long Pay(BankAccount target, long amount, string bankName)
        {
            if (target == null)
            {
                Console.WriteLine("==> Tài khoản đích không tồn tại. <==");
                return -1;
            }
            else
            {
                if (amount <= Balance - 50000)
                {
                    Balance -= amount;
                    target.Balance += amount;
                    var fee = 0;
                    if (bankName != null)
                    {
                        // thanh toán trên app
                        fee = 1100;
                        if (bankName.CompareTo(Bank) != 0) // thanh toán tại ATM
                        {
                            fee = 3300;
                        }
                    }
                    fee += (int)(3.0 / 100 * amount);
                    Balance -= fee;
                    Console.WriteLine("==> Thanh toán thành công. <==");
                    return amount;
                }
                else
                {
                    Console.WriteLine("==> Số dư không đủ. Thanh toán thất bại. <==");
                    return -1;
                }
            }
        }

        public override long Withdraw(long amount, string bankName)
        {
            if (amount <= Balance + 50000)
            {
                var fee = 1100;
                if (bankName.CompareTo(Bank) != 0)
                {
                    fee = 3300;
                }
                fee += (int)(3.0 / 100 * amount);
                Balance = Balance - amount - fee;
                var dateTimeFormat = "dd/MM/yyyy HH:mm:ss";
                Console.WriteLine("==> Rút tiền thành công");
                Console.WriteLine($"==> Thời gian giao dịch: {DateTime.Now.ToString(dateTimeFormat)}");
                return (amount + fee);
            }
            else
            {
                Console.WriteLine("==> Số dư của bạn không đủ để thực hiện giao dịch này. <==");
                return -1;
            }
        }
    }
}
