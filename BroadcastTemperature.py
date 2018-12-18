BROADCAST_TO_PORT = 7000
import time
from socket import *
from sense_hat import SenseHat
from datetime import datetime

sense = SenseHat()
sense.clear()

s = socket(AF_INET, SOCK_DGRAM)
#s.bind(('192.168.24.106', 7000))
#(ip, port)

s.setsockopt(SOL_SOCKET, SO_BROADCAST, 1)

while True:
	data = str(sense.get_temperature())
	s.sendto(bytes(data, "UTF-8"), ('<broadcast>', BROADCAST_TO_PORT))
	print(data)
	time.sleep(10)
