import numpy as np
import matplotlib.pyplot as plt


def f(x):  # функція розгорнутого гіпереліпсоїду
    return x[0] ** 2 + 2 * x[1] ** 2


def df(x):  # функція для градієнту
    return np.array([2 * x[0], 4 * x[1]])


x0 = np.array([3.2, 3.2])  # Початкова точка
alpha = 0.16  # 2/12.65 Крок градієнтного спуску

eps1 = 0.0001  # точність обчислень
eps2 = 0.0001


def gradient_descent(f, df, x0, alpha, eps1, eps2):  # функція градієнтого спуску с постійним кроком

    history = [x0]  # Ініціалізуємо список точок, де ми вже пройшли та додаємо перший елемент

    i = 0  # Кількість ітерацій
    xper = x0  # Значення минулої точки
    while np.linalg.norm(df(xper)) > eps1:  # поки норма градієнту більше за епсілон1

        grad = df(history[i])  # Рахуємо градієнт функції для поточної точки
        x = history[i] - alpha * grad # Оновлюємо поточну точку, віднявши значення градієнту у ній помноженій на крок
        if abs(f(x) - f(xper)) < eps2 or np.linalg.norm((x - xper)) < eps2:  # Умова кінця ітерацій: різниця значень у точці менше епсілон чи норма різниці точок менша за епсілон
            break
        i += 1
        history.append(x)  # Додаємо нову точку до списку точок
        xper = history[i]  # Оновлюємо значення минулої точки
    # Повертаємо значення точки, лист точок та кількість ітерацій.
    return history[i], history, i


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
    plt.title(f'Gradient descent: fmin = {fmin:.2f}')
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
    plt.title(f'Gradient descent: fmin = {fmin:.2f}')
    plt.plot(path[:, 0], path[:, 1], '-o', color='red', markersize=4)
    plt.xlabel('x')
    plt.ylabel('y')
    plt.show()


# Викликаємо метод градієнтного спуску
opt_point, history, iter = gradient_descent(f, df, x0, alpha, eps1, eps2)

# Вивід кількості ітерацій, точки мінімуму та значення у ній
print("Кількість ітерацій: ", iter)
print("Точка мінімуму: ", opt_point)
print("Значення цільової функції: ", f(opt_point))
plot_hj_configuration(opt_point, f(opt_point), f, history)  # Візуальна частина
