import cv2 # OpenCV
from cvzone.PoseModule import PoseDetector # Pose detection module

# Web Camera
cap = cv2.VideoCapture(0) # Camera Number
cap.set(3, 1280) # Width
cap.set(4, 720) # Height

# Pose Detector
detector = PoseDetector()

while True:
    success, img = cap.read() # Detecting the camera and continue to read the camera if a camera is present

    # Pose
    img = detector.findPose(img)
    lmList, bboxInfo = detector.findPosition(img, bboxWithHands=True)

    # Display
    cv2.imshow("Webcam", img)
    cv2.waitKey(1)