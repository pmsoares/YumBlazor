﻿namespace YumBlazor.Services
{
    public class SharedStateServices
    {
        public event Action? OnChange;

        private int _totalCartCount;

        public int TotalCartCount
        {
            get => _totalCartCount;

            set
            {
                _totalCartCount = value;
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
