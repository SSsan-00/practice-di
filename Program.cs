// 抽象(インターフェース)
public interface IMessageService
{
  void Send(string message);
}

// 実装
public class MessageService : IMessageService
{
  public void Send(string message)
  {
    Console.WriteLine($"送信内容: {message}");
  }
}

// 実装(Slack)
public class SlackService : IMessageService
{
  public void Send(string message)
  {
    Console.WriteLine($"Slack送信: {message}");
  }
}

// 通知を行うクラス
public class Notification
{
  // interfaceに依存する
  private readonly IMessageService _messageService;

  // コンストラクタで受け取る
  public Notification(IMessageService messageService)
  {
    _messageService = messageService;
  }

  public void Notify()
  {
    _messageService.Send("interface版の通知です");
  }
}

class Program
{
  static void Main()
  {
    // ここで実装を選ぶ
    IMessageService messageService = new SlackService();

    // Notificationを外から渡す
    var notification = new Notification(messageService);

    // 通知を実行する
    notification.Notify();
  }
}
