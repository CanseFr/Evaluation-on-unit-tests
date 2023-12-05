namespace EvaluationSampleCode.UnitsTests
{
    [TestFixture]
    public class ReservationTests
    {
        private User _user;
        private User _admin;
        private Reservation _reservation;

        [SetUp]
        public void SetUp()
        {
            _user = new User { IsAdmin = false };
            _admin = new User { IsAdmin = true };
            _reservation = new Reservation(_user);
        }

        [Test]
        public void CanBeCancelBy_UserIsAdmin_ReturnTrue()
        {
            var result = _reservation.CanBeCancelledBy(_admin);
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelBy_SameUserCanceling_ReturnTrue()
        { 
            var result = _reservation.CanBeCancelledBy(_user);
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelBy_AnotherUserCanceling_ReturnFalse()
        {
            var anotherUser = new User { IsAdmin = false };
            var result = _reservation.CanBeCancelledBy(anotherUser);
            Assert.IsFalse(result);
        }
    }
}