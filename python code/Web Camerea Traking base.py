import cv2 # OpenCV
from cvzone.HandTrackingModule import HandDetector # Hand tracking module

# open cv and media pipe are part of the cvzone library you will need to install it and media pipe to run this code

# Web Camera
cap = cv2.VideoCapture(0) # Camera Number
cap.set(3, 1280) # Width 
cap.set(4, 720) # Height

# Hand Detector
detector = HandDetector(maxHands =4, detectionCon= 0.8)

while True:
    success, img = cap.read() # detecting the camera and continue to read the camera if a camera is present
    
    # Hands
    hands, img = detector.findHands(img)
    
    # Transferring landmark data to Unity
    
    
    # Display
    cv2.imshow("Webcam", img)
    cv2.waitKey(1)