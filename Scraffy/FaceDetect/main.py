# -*- coding: utf-8 -*-
import cv2

def process(img):
    cascade = cv2.CascadeClassifier('haarcascades\haarcascade_frontalface_default.xml')
    nested = cv2.CascadeClassifier('haarcascades/haarcascade_eye.xml')
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    gray = cv2.equalizeHist(gray)
    faces = detect(gray, cascade)
    vis = img.copy()
    draw_rects(vis, faces, (0, 255, 0))
    if not nested.empty():
        for x1, y1, x2, y2 in faces:
            roi = gray[y1:y2, x1:x2]
            vis_roi = vis[y1:y2, x1:x2]
            eyes = detect(roi.copy(), nested)
            draw_rects(vis_roi, eyes, (255, 0, 0))
    return vis

def detect(img, cascade):
    rects = cascade.detectMultiScale(img, scaleFactor=1.3, minNeighbors=4, minSize=(30, 30),
                                     flags=cv2.CASCADE_SCALE_IMAGE)
    if len(rects) == 0:
        return []
    rects[:,2:] += rects[:,:2]
    return rects

def draw_rects(img, rects, color):
    for x1, y1, x2, y2 in rects:
        cv2.rectangle(img, (x1, y1), (x2, y2), color, 2)

def show_webcam(detect=False):
    cap = cv2.VideoCapture(0)
    print('cam resolution: ', cap.get(3), 'x', cap.get(4))
    while (True):
        # Capture frame-by-frame
        ret, frame = cap.read()
        if detect:
            frame = process(frame)
        cv2.imshow('my webcam', frame)
        if cv2.waitKey(5) == 27: 
            break  # esc to quit
    cap.release
    cv2.destroyAllWindows()

def show_image(img):
    cv2.imshow('test image', img)
    cv2.waitKey(0)
    cv2.destroyAllWindows()

def main():
    print('using openCV version:', cv2.__version__)
    #show_image(cv2.imread('lena.jpg'))
    show_webcam(True)

if __name__ == '__main__':
    main()