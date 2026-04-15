using Microsoft.VisualStudio.TestTools.UnitTesting;

// テスト用プロジェクトの名前空間
namespace practice_di.Tests;

// IMessageService のテスト実装
// 呼び出されたかどうかを確認するために、値を保持する
public class TestMessageService : IMessageService
{
    // Send が呼ばれたかどうか
    public bool WasCalled { get; private set; }

    // 渡されたメッセージを保持する
    public string? SentMessage { get; private set; }
    
    public void Send(string message)
    {
        WasCalled = true;
        SentMessage = message;
    }
}

[TestClass]
public class NotificationTests
{
    [TestMethod]
    public void NotifyAfterCalledSend()
    {
        // Arrange
        // テスト用の IMessageService 実装を作る
        var testMessageService = new TestMessageService();

        // Notifycation に外から渡す
        var notifycation = new Notification(testMessageService);

        // Act
        // 実際に通知処理を実行する
        notifycation.Notify();

        // Assert
        // Send が呼ばれたことを確認する
        Assert.IsTrue(testMessageService.WasCalled);
    }
}
