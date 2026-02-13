namespace Assets.Project.Scripts.Ground.Filler
{
    public class LevelHazard
    {
        private ILevelHazard _levelHazard;

        public LevelHazard(ILevelHazard levelHazard) =>
            _levelHazard = levelHazard;

        public void StartLevel() =>
            _levelHazard.StartScale();

        public void Stop() =>
            _levelHazard.Stop();

        public void Reset() =>
            _levelHazard.ResetFiller();
    }
}