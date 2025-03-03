using DesignPatternsNet.Creational.Singleton;
using Xunit;

namespace DesignPatternsNet.Tests.Creational
{
    public class SingletonTests
    {
        [Fact]
        public void AppConfigurationManager_GetInstance_ReturnsSameInstance()
        {
            // Act
            var instance1 = AppConfigurationManager.Instance;
            var instance2 = AppConfigurationManager.Instance;
            
            // Assert
            Assert.NotNull(instance1);
            Assert.NotNull(instance2);
            Assert.Same(instance1, instance2);
        }
        
        [Fact]
        public void AppConfigurationManager_SetAndGetSetting_WorksCorrectly()
        {
            // Arrange
            var instance = AppConfigurationManager.Instance;
            var key = "TestKey";
            var value = "TestValue";
            
            // Act
            instance.SetSetting(key, value);
            var retrievedValue = instance.GetSetting(key);
            
            // Assert
            Assert.Equal(value, retrievedValue);
        }
        
        [Fact]
        public void AppConfigurationManager_GetNonExistentSetting_ReturnsEmptyString()
        {
            // Arrange
            var instance = AppConfigurationManager.Instance;
            var key = "NonExistentKey";
            
            // Act
            var value = instance.GetSetting(key);
            
            // Assert
            Assert.Equal(string.Empty, value);
        }
    }
}
