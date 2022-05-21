/// <summary>
/// <author>Branium Academy</author>
/// <version>2022.05.20</version>
/// <see cref="Trang chủ" href="https://braniumacademy.net"/>
/// </summary>

using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesLesson610
{
    class Exercises2
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

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
        // chuyển tiền
        public abstract long BankTransfer(BankAccount other, long amount, string bankName);
        // thanh toán hóa đơn, dịch vụ
        public abstract long Pay(BankAccount target, long amount, string bankName);
    }

    class CheckingAccount : BankAccount
    {
        public long PaymentLimit { get; set; }
        public long TotalPayment { get; set; } // tổng tiền thanh toán, rút, chuyển

        public CheckingAccount() { }

        public CheckingAccount(string bankAcc) : base(bankAcc) { }

        public CheckingAccount(string accNum, string owner, string bank,
            string releaseDate, long balance, double interestRate, long limit) :
            base(accNum, owner, bank, releaseDate, balance, 1)
        {
            PaymentLimit = limit;
            TotalPayment = 0;
        }

        public override long BankTransfer(BankAccount other, long amount, string bankName)
        {
            throw new NotImplementedException();
        }

        public override void CheckBallance(string bankName)
        {
            var dateTimeFormat = "dd/MM/yyyy HH:mm:ss";
            Console.WriteLine("======== THÔNG TIN TÀI KHOẢN ========");
            Console.WriteLine($"Số tài khoản: {AccountNumber}");
            Console.WriteLine($"Loại tài khoản: Thanh toán");
            Console.WriteLine($"Số dư: {Balance}");
            Console.WriteLine($"Ngày phát hành: {ReleaseDate}");
            Console.WriteLine($"Thời gian thực hiện: {DateTime.Now.ToString(dateTimeFormat)}");
            Console.WriteLine("=====================================");
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
            throw new NotImplementedException();
        }

        public override long Withdraw(long amount, string bankName)
        {
            if (amount > Balance + 50000)
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
                return (amount + fee);
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
        public int Term { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public SavingAccount() { }

        public SavingAccount(string accNum) : base(accNum) { }

        public SavingAccount(string accNum, string owner, string bank,
            string releaseDate, long balance, int term, DateTime start, DateTime end) :
            base(accNum, owner, bank, releaseDate, balance, 0)
        {
            Term = term;
            StartDate = start;
            EndDate = end;
        }

        public override long BankTransfer(BankAccount other, long amount, string bankName)
        {
            throw new NotImplementedException();
        }

        public override void CheckBallance(string bankName)
        {
            var format = "dd/MM/yyyy";
            var dateTimeFormat = "dd/MM/yyyy HH:mm:ss";
            Console.WriteLine("======== THÔNG TIN TÀI KHOẢN ========");
            Console.WriteLine($"Số tài khoản: {AccountNumber}");
            Console.WriteLine($"Loại tài khoản: Tiết kiệm");
            Console.WriteLine($"Số dư: {Balance}");
            Console.WriteLine($"Ngày phát hành: {ReleaseDate}");
            Console.WriteLine($"Kỳ hạn: {Term}");
            Console.WriteLine($"Lãi suất: {InterestRate}%");
            Console.WriteLine($"Hiệu lực từ: {StartDate.ToString(format)}");
            Console.WriteLine($"Hiệu lực đến: {EndDate.ToString(format)}");
            Console.WriteLine($"Thời gian thực hiện: {DateTime.Now.ToString(dateTimeFormat)}");
            Console.WriteLine("=====================================");
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
            throw new NotImplementedException();
        }

        public override long Withdraw(long amount, string bankName)
        {
            if (amount > Balance + 50000)
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
