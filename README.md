Cách sử dụng Command Pattern
Để hiểu cách sử dụng nó chúng ta sẽ thông qua 1 ví dụ như sau: Cùng khởi tạo playground để demo cách sử dụng: Chúng ta có một đối tượng Light có 2 phương thức là switchOn và switchOff: Đây đóng vai trò là 1 class request

class Light {
    func switchOn() {
        print("light on")
    }
    
    func switchOff() {
        print("light off")
    }
}

Như đã mô tả ở phần trên thì Command pattern cần có 5 thành phần vì vậy chúng ta sẽ từng bước xây dựng nó. Chúng ta xây dựng 1 interface tên là Command không trực tiếp tắt bật đèn mà chỉ ra lệnh cho light on or off.

protocol Command {
    func execute()
}

sau đó chúng ta sẽ khởi tạo 2 class CommandOff và CommandOn implement Command: 2 class này chính là ConcreteCommand

class CommandOff: Command {
    func execute() {
        Light().switchOff()
    }
}


class CommandOn: Command {
    func execute() {
        Light().switchOn()
    }
}

Tiếp theo tiến hành đóng gói các command này vào trong 1 bộ điều khiển gọi là Remote Control: class này đóng vai trò là invoker

class RemoteControl {
    private var command: Command?
    
    func setCommand(command: Command) {
        self.command = command
    }
    
    func run() {
        command?.execute()
    }
}

Vậy thì với RemoteControll chúng ta có thể truyền các command khác nhau vào để thực hiện các chức năng riêng biệt khác nhau. Re quest được đóng giói dưới dạng object đúng như trong tư tưởng của pattern.

Chúng ta tạo 1 client để thực thi và xem kết quả:

let remote = RemoteControl()
let commandOff = CommandOff()
remote.setCommand(command: commandOff)
remote.run()

và kết quả là: light off

Từ ví dụ trên chắc ae cũng có thể hiểu được cơ bản cách thức để xây dựng và sử dụng của một command pattern.

Command pattern khá hữu dụng nhưng ta nên sử dụng những khi:

Khi cần tham số hóa các đối tượng theo một hành động thực hiện.
Khi cần tạo và thực thi các yêu cầu vào các thời điểm khác nhau.
Khi cần hỗ trợ tính năng undo, log , callback hoặc transaction.
