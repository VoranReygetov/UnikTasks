from tkinter import *
from tkinter import filedialog
from PIL import Image, ImageTk
import cv2


class ImageConverter:
    def __init__(self, app):
        self.app = app
        app.title("Image Converter")
        app.geometry("800x600")

        self.image_path = ""
        self.original_image = None

        # створюємо область майбутньої картинки
        self.img_label = Label(app)
        self.img_label.place(x=50, y=220)

        # створюємо кнопки для відкриття файлу
        self.open_button = Button(app, text="Open Image", command=self.open_image)
        self.open_button.grid(row=0, column=0)

        # створюємо область назви картинки
        self.open_label = Label(app)
        self.open_label.place(x=200, y=10)

        # створюємо кнопку для конвертування зображення в GIF
        self.convert_gif_button = Button(app, text="Convert to PNG", command=self.convert_image_to_png)
        self.convert_gif_button.grid(row=7, column=0)

        # створюємо кнопку для конвертування зображення в JPEG
        self.convert_jpeg_button = Button(app, text="Convert to JPEG", command=self.convert_image_to_jpeg)
        self.convert_jpeg_button.grid(row=7, column=1)

        # створюємо поля для вводу параметрів зміни розміру
        self.scale_label = Label(app, text="Enter scaling parameters (X, Y):")
        self.scale_label.grid(row=2, column=0)
        self.scale_x = Entry(app)
        self.scale_y = Entry(app)
        self.scale_x.grid(row=3, column=0)
        self.scale_y.grid(row=3, column=1)

        # створюємо поля для вводу параметрів зміни масштабу
        self.scaling_label = Label(app, text="Enter separate scaling:")
        self.scaling_label.grid(row=5, column=0)
        self.scaling = Entry(app)
        self.scaling.grid(row=6, column=0)

        # створюємо кнопку для зміни розміру зображення
        self.resize_button = Button(app, text="Resize Image", command=self.resize_image)
        self.resize_button.grid(row=1, column=0)

        # створюємо поля для означення використання фільтрів та зміни типу
        self.convert_label = Label(app, text="")
        self.convert_label.grid(row=8, column=1)

        # створюємо кнопку для зміни масштабу зображення
        self.resize_button = Button(app, text="Rescale Image", command=self.change_scale)
        self.resize_button.grid(row=4, column=0)

        # створюємо кнопку для накладання фільтру "BLUR"
        self.blur_button = Button(app, text="Apply BLUR Filter", command=self.blur_filter)
        self.blur_button.grid(row=8, column=0)

    def change_image(self, new_image):  # функція для зміни картинки на екрані
        img = Image.open(new_image)
        img = img.convert('RGB')
        img.thumbnail([512, 256])
        img2 = ImageTk.PhotoImage(img)
        self.img_label.configure(image=img2)
        self.img_label.image = img2

    def open_image(self):
        # відкриваємо файловий діалог для вибору файлу
        self.image_path = filedialog.askopenfilename(filetypes=[("PNG Files", "*.png"), ("JPEG Files", "*.jpg;*.jpeg")])
        # відкриваємо зображення за допомогою бібліотеки PIL
        self.original_image = Image.open(self.image_path)
        self.open_label.config(text="Opened image: {}".format(self.image_path))
        self.change_image(self.image_path)

    def convert_image_to_png(self):  # функція конвертації у PNG
        if self.original_image:
            jpeg_path = self.image_path[:-4] + ".png"
            # зберігаємо зображення в форматі GIF
            self.original_image.save(jpeg_path, "PNG")
            self.convert_label.config(text="Saved in PNG")
            self.change_image(self.image_path)

    def convert_image_to_jpeg(self):  # функція конвертації у JPEG
        if self.original_image:
            png_path = self.image_path[:-4] + ".jpg"
            # зберігаємо зображення в форматі JPEG
            image_rgb = self.original_image.convert('RGB')
            image_rgb.save(png_path, "JPEG")
            self.convert_label.config(text="Saved in JPEG")
            self.change_image(self.image_path)

    def resize_image(self):  # функція для зміни розміру зображення
        if self.original_image and self.scale_x.get() and self.scale_y.get():
            # зміна розміру зображення за допомогою введених параметрів масштабування
            x_scale = int(self.scale_x.get())
            y_scale = int(self.scale_y.get())
            image = cv2.imread(self.image_path)
            res = cv2.resize(image, (x_scale, y_scale))
            cv2.imwrite(self.image_path, res)
            self.scale_label.config(text=f"Size changed to: {x_scale}, {y_scale}")
            self.change_image(self.image_path)

    def change_scale(self):  # функція для зміни масштабу у к раз
        if self.original_image and self.scaling.get():
            k = float(self.scaling.get())
            (width, height) = self.original_image.size
            width1 = k * width
            height1 = k * height
            image = cv2.imread(self.image_path)
            res = cv2.resize(image, (int(width1), int(height1)))
            cv2.imwrite(self.image_path, res)
            self.scaling_label.config(text=f"Scale changed in {self.scaling.get()} times")
            self.change_image(self.image_path)

    def blur_filter(self):  # функція для збереження фільтру BLUR
        if self.original_image:
            image = cv2.imread(self.image_path)
            blurred_image = cv2.blur(image, (5, 5))
            cv2.imwrite(self.image_path, blurred_image)
            self.convert_label.config(text="Applied BLUR filter")
            self.change_image(self.image_path)


root = Tk()
my_gui = ImageConverter(root)
root.mainloop()
