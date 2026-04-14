using System;

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
  private readonly MessageService _messageService = new MessageService();

  public void Notify()
  {
    _messageService.Send("DIなしの通知です");
  }
}

class Program
{
  static void Main()
  {
    // Notification作成
    var notification = new Notification();

    // 通知を実行する
    notification.Notify();
  }
}
