import numpy as np
import matplotlib.pyplot as plt


def f(x):  # функція розгорнутого гіпереліпсоїду
    return x[0] ** 2 + 2 * x[1] ** 2


def grad(x):  # функція для градієнту
    return np.array([2 * x[0], 4 * x[1]])


def hess(x):  # обернена матриця Гессе для нашої функції
    return np.array([[1 / 4, 0], [0, 1 / 2]])


x0 = np.array([3.2, 3.2])  # Початкова точка
a = 0.16  # 2/12.65 Крок градієнтного спуску
epsilon = 0.0001  # точність обчислень


def newton_method(f, grad, hess, x0, epsilon):  # функція методу ньютона

    history = [x0]  # Ініціалізуємо список точок, де ми вже пройшли та додаємо перший елемент
    i = 0  # Кількість ітерацій
    xper = x0  # Значення минулої точки

    while abs(f(history[i])) > epsilon and np.linalg.norm(xper) > epsilon:  # Умова кінця ітерацій: значення у точці чи норма координат менше за епсілон
        x = xper - a * np.linalg.solve(hess(xper), grad(xper))  # Самий метод наближення
        i += 1
        history.append(x)  # Додаємо нову точку до списку точок
        xper = history[i]  # Оновлюємо значення минулої точки
    # Повертаємо значення точки, лист точок та кількість ітерацій.
    return x, history, i


def plot_hj_configuration(xmin, fmin, f, path):  # Функція для візуалізації графіку та шляху методу
    x_min, x_max = -5, 5
    y_min, y_max = -5, 5
    x = np.linspace(x_min, x_max, 100)
    y = np.linspace(y_min, y_max, 100)
    X, Y = np.meshgrid(x, y)
    Z = f([X, Y])
    path = np.array(path)

    # Відображення 3d графіку
    fig = plt.figure(figsize=(5, 5))
    ax = fig.add_subplot(111, projection='3d')
    plt.title(f'Newton method: fmin = {fmin:.2f}')
    plt.plot(*xmin, 'b*', markersize=12)
    ax.contour3D(X, Y, Z, 50, cmap='binary')
    plt.plot(path[:, 0], path[:, 1], '-o', color='red', markersize=4)
    ax.set_xlabel('x')
    ax.set_ylabel('y')
    ax.set_zlabel('z')
    plt.show()

    # Відображення 2d графіку
    plt.contour(X, Y, Z, 50, levels=50)
    plt.plot(*xmin, 'b*', markersize=12)
    plt.title(f'Newton method: fmin = {fmin:.2f}')
    plt.plot(path[:, 0], path[:, 1], '-o', color='red', markersize=4)
    plt.xlabel('x')
    plt.ylabel('y')
    plt.show()


# Викликаємо метод Ньютона
x, history, iter_count = newton_method(f, grad, hess, x0, epsilon)
# Вивід кількості ітерацій, точки мінімуму та значення у ній
print("Кількість ітерацій: ", iter_count)
print("Точка мінімуму: ", x)
print("Значення цільової функції: ", f(x))
plot_hj_configuration(x, f(x), f, history)  # Візуальна частина
