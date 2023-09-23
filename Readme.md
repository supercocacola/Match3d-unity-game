# Đánh giá về lợi thé và bất lợi của cách thiết kế và tổ chức project
✨ __Lợi thế:__
- Sử dụng state pattern đảm bảo việc trong 1 thời điểm sẽ luôn xác định được trạng thái rõ ràng của game khiến việc thêm state khác vào ko ảnh hưởng tới cái state đã có, loại bỏ được các lệnh if else xét trường hợp
- Sử dụng thư mục Resource để lưu trữ asset có thể nhanh khi làm prototype, dễ dàng load các file bất đồng bộ
- Các object trong scene được sinh ra tuần tự khiến dễ kiểm soát luồng và thứ tự chạy của code
- Mọi event và object đc sinh thực hiện trong runtime nên việc thay đổi sẽ chỉ cần thay đổi trong code khiến khi xảy ra conflict cũng dễ dàng được xử lý hơn
✨ __Bất lợi:__
- Sử dụng state pattern khiến khi mở rộng project có thể gặp các state tương tự nhau hoặc có điểm giống nhau khiến code bị trùng lặp khi xử lý hành vi và điều kiện chuyển đổi giữa các trạng thái
- Lưu trữ và sử dụng asset trong thư mục Resources có thể dẫn đến vấn đề về hiệu năng và dung lượng file build theo như Unity khuyến nghị [Unity - The Resources folder](https://docs.unity3d.com/Manual/BestPracticeUnderstandingPerformanceInUnity6.html) và khi dự án lớn hơn có thể dẫn đến việc khó quản lý asset
- Các object đc sinh ra trong runtime nên sẽ không trực quan

# Những điểm có thay đổi trong tổ chức project
- Ngoài các file setting chung của toàn bộ project thì các asset khác có thể được đóng gói sử dụng addressable. Việc này sẽ khiến việc quản lý bộ nhớ đươc tối ưu hơn. Kết hợp cùng scriptable object để load và release các asset không sử dụng và kết hợp với pooling để tối ưu ram sử dụng. Ngoài ra sử dụng addressable sẽ dễ dàng hơn trong việc modding game như trên đây [Introduction to Modding Unity Games With Addressables](https://www.kodeco.com/14494028-introduction-to-modding-unity-games-with-addressables) 
- Các resource như ảnh, âm thanh đều cần được nén tùy vào phần cứng và phần mềm mà sản phẩn hướng đến nhằm việc tối ưu performance và dung lượng bản build
- Có thể chỉ sử dụng 1 Monobehaviour để chạy các coroutine để tăng performance 