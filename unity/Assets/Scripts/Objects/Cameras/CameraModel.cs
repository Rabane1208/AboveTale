namespace AT.Object
{
    public class CameraModel
    {
        public float MoveSpeed { get; private set; }

        public CameraModel(float moveSpeed)
        {
            MoveSpeed = moveSpeed;
        }
    }
}