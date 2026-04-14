
// メッセージを送るクラス
public class MessageService
{
  public void Send(string message)
  {
    Console.WriteLine($"送信内容: {message}");
  }
}

// 通知を行うクラス
public class Notification
{
  private readonly MessageService _messageService;

  // コンストラクタで受け取る
  public Notification(MessageService messageService)
  {
    _messageService = messageService;
  }

  public void Notify()
  {
    _messageService.Send("DIありの通知です");
  }
}

class Program
{
  static void Main()
  {
    // 先にMessageServiceを作る
    var messageService = new MessageService();

    // Notificationを外から渡す
    var notification = new Notification(messageService);

    // 通知を実行する
    notification.Notify();
  }
}
