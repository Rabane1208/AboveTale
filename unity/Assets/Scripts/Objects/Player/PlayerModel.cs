namespace AT.Object
{
    public class PlayerModel
    {
        public float MoveSpeed { get; private set; }
        public float RotateSpeed { get; private set; }

        public PlayerModel(float moveSpeed, float rotateSpeed)
        {
            MoveSpeed = moveSpeed;
            RotateSpeed = rotateSpeed;
        }
    }
}