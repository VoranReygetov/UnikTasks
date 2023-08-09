import numpy as np
import matplotlib.pyplot as plt


class Coordinate:  # створюємо клас з координатами нашої функції

    def __init__(self, x, y):
        self.x = x
        self.y = y


def func(x, y):
    return (x ** 2) + (y ** 2)  # функція варіанту номер 4


accuracy = 0.0001  # точність
borders = Coordinate(2, -2)  # об'являємо границі функції

top = Coordinate(0, 1)
right = Coordinate(1, 0)
bottom = Coordinate(0, -1)  # координатні напрямки
left = Coordinate(-1, 0)

directions = [top, right, bottom, left]

print("Введіть x:")
x = float(input())

print("Введіть y:")
y = float(input())

basis = Coordinate(x, y)  # утворюємо базис

print("Введіть крок:")
step = float(input())  # крок функції

z = 0.0

while step >= accuracy:
    while 0 < 1:
        print("Досліджувальний пошук")
        z = func(basis.x, basis.y)  # підставляємо значення базису
        tempList = []

        for direction in directions:
            tempb = Coordinate(
                basis.x + (direction.x * step),
                basis.y + (direction.y * step))  # утворюємо тимчасовий базис
            tempList.append(func(tempb.x, tempb.y))
        if min(tempList) < z:
            IndexMinCoordinate = tempList.index(min(tempList))
            direction = directions[IndexMinCoordinate]  # визначили напрямок з мінімальним значенням функції
            basis = Coordinate(basis.x + (direction.x * step),
                               basis.y + (direction.y * step))
            break
        elif min(tempList) >= z:
            step = step / 10
            break

    tempZ = 1000

    if step >= accuracy:
        while 0 < 1:
            print("Пошук за зразком")
            z = func(basis.x, basis.y)
            tempb = Coordinate(basis.x + (direction.x * step),
                               basis.y + (direction.y * step))
            tempZ = func(tempb.x, tempb.y)
            if tempZ < z:
                basis = tempb
            else:
                break
    else:
        break

print("Мінімальна точка функції з точністю 0.0001 має координати:")
print(F"x = {basis.x}")
print(F"y = {basis.y}")
print(F"z = {z}")

X = np.linspace(-5, 5, 50)
Y = np.linspace(-5, 5, 50)

X, Y = np.meshgrid(X, Y)

Z = func(X, Y)

fig = plt.figure(figsize=(5, 5))
ax = fig.add_subplot(111, projection='3d')
ax.contour3D(X, Y, Z, 50, cmap='binary')
ax.set_xlabel('x')
ax.set_ylabel('y')
ax.set_zlabel('z')
plt.show()
