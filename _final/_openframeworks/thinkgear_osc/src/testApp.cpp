#include "testApp.h"

void testApp::setup()
{
	ofSetCircleResolution(50);
    ofSetFrameRate(30);
    ofEnableAlphaBlending();
    
    thinkGear.setup();
    ofAddListener(thinkGear.attentionChangeEvent, this, &testApp::attentionListener);
    ofAddListener(thinkGear.meditationChangeEvent, this, &testApp::meditationListener);
	ofAddListener(thinkGear.blinkChangeEvent, this, &testApp::blinkListener);
    
    font.loadFont("font/DroidSansMono.ttf", 20);
    
    distAw = 0.0;
    prevAw = 0.0;
    currAw = 0.0;
    distMw = 0.0;
    prevMw = 0.0;
    currMw = 0.0;
    
    atChangeTime = 0.0;
    attention = 0.0;
    meChangeTime = 0.0;
    meditation = 0.0;
	
	//osc sender begin
	ofBackground(40, 100, 40);
	
	// open an outgoing connection to HOST:PORT
	sender.setup(HOST, PORT);
	//osc sender end
}

//--------------------------------------------------------------

void testApp::update()
{
    thinkGear.update();
    
    float cur = ofGetElapsedTimef();
    float progress = cur - atChangeTime;
    progress = ofClamp(progress, 0.0, 1.0);
    if (progress == 0.0) prevAw = currAw;
    currAw = ofxTweenLite::tween(prevAw, distAw, progress, OF_EASE_SINE_INOUT);
    
    progress = cur - meChangeTime;
    progress = ofClamp(progress, 0.0, 1.0);
    if (progress == 0.0) prevMw = currMw;
    currMw = ofxTweenLite::tween(prevMw, distMw, progress, OF_EASE_SINE_INOUT);
}

//--------------------------------------------------------------

void testApp::draw()
{
    ofBackgroundGradient(ofColor::white, ofColor::gray);
    
    ofPushStyle();
    ofSetColor(ofColor::black);
    string qStr = "";
    if (thinkGear.getSignalQuality() == 0.0)
    {
        qStr = "good";
    }
    else
    {
        qStr = "poor (" + ofToString(thinkGear.getSignalQuality()) + ")";
    }
    font.drawString("signal quality = " + qStr, 10, 40);
    ofPopStyle();
	
	//blink
	font.drawString("Blink", 10, (blink));
    
    //attention bar
    ofPushMatrix();
    ofTranslate(0, 30);
    ofPushStyle();
    ofSetColor(ofColor::black);
    font.drawString("Attention", 10, ofGetHeight()/11 - 10);
    ofNoFill();
    ofCircle(ofGetWidth()/2, ofGetHeight()/2, currAw);
    //	ofRect(1, ofGetHeight()/11, ofGetWidth() - 2, 60);
    ofSetColor(ofColor::yellow, ofMap(currAw, 0.0, ofGetWidth(), 50, 255));
    ofFill();
	ofCircle(ofGetWidth()/2, ofGetHeight()/2, currAw);
    //  ofRect(0, ofGetHeight()/11, currAw, 59);
    if (attention > 0.0)
    {
        ofSetColor(ofColor::black, ofMap(currAw, 0.0, ofGetWidth(), 50, 255));
        font.drawString(ofToString(attention), 10, ofGetHeight()/11 + 40);
    }
    ofPopStyle();
    ofPopMatrix();
    
	//key circle
	ofSetColor(ofColor::black);
    //	ofTranslate(0, 30);
	ofCircle(ofGetWidth()/2, (ofGetHeight()/2)+30, 2);
	
	//meditation bar
    ofPushMatrix();
    ofTranslate(0, 30);
    ofPushStyle();
    ofSetColor(ofColor::black);
    font.drawString("Meditation", 10, (ofGetHeight()/3.5) - 10);
    ofNoFill();
	ofCircle(ofGetWidth()/2, ofGetHeight()/2, currMw);
    //  ofRect(1, (ofGetHeight()/3.5), ofGetWidth() - 2, 60);
    ofSetColor(ofColor::cyan, ofMap(currMw, 0.0, ofGetWidth(), 50, 255));
    ofFill();
	ofCircle(ofGetWidth()/2, ofGetHeight()/2, currMw);
    //	ofRect(0, (ofGetHeight()/3.5), currMw, 59);
    if (meditation > 0.0)
    {
        ofSetColor(ofColor::black, ofMap(currMw, 0.0, ofGetWidth(), 50, 255));
        font.drawString(ofToString(meditation), 10, (ofGetHeight()/3.5) + 40);
    }
    ofPopStyle();
    ofPopMatrix();
    
    ofSetWindowTitle("fps = " + ofToString(ofGetFrameRate()));
	
	//osc sender begin
	// display instructions
	string buf;
	buf = "sending osc messages to" + string(HOST) + ofToString(PORT);
	ofDrawBitmapString(buf, 10, 20);
	ofDrawBitmapString("move the mouse to send osc message [/mouse/position <x> <y>]", 10, 50);
	ofDrawBitmapString("click to send osc message [/mouse/button <button> <\"up\"|\"down\">]", 10, 65);
	ofDrawBitmapString("press A to send osc message [/test 1 3.5 hello <time>]", 10, 80);
    

    
    ofxOscMessage m;
    
    m.setAddress("/neurosky");
    m.addIntArg(meditation);
    m.addIntArg(attention);
    m.addIntArg(blink);
    
    cout << "meditation: " << m.getArgAsInt32(0) <<endl;
    cout << "attention: " << m.getArgAsInt32(1) <<endl;
    cout << "blink: " << m.getArgAsInt32(2) <<endl;

    sender.sendMessage(m);    
    
	//osc sender end
}

//--------------------------------------------------------------

void testApp::attentionListener(float &param)
{
    attention = param;
    distAw = ofMap(attention, 0.0, 100.0, 0, ofGetWidth());
    atChangeTime = ofGetElapsedTimef();
}

//--------------------------------------------------------------

void testApp::meditationListener(float &param)
{
    meditation = param;
    distMw = ofMap(meditation, 0.0, 100.0, 0, ofGetWidth());
    meChangeTime = ofGetElapsedTimef();
}

//--------------------------------------------------------------

void testApp::blinkListener(float &param)
{
    //    meditation = param;
    //    distMw = ofMap(meditation, 0.0, 100.0, 0, ofGetWidth());
    //    meChangeTime = ofGetElapsedTimef();
    //	cout << "blink: "<<param<<endl;
	blink = param;
    
}

//--------------------------------------------------------------
void testApp::keyPressed(int key){
//	if(key == 'a' || key == 'A'){
//		ofxOscMessage m;
//		m.setAddress("/test");
//		m.addIntArg(1);
//		m.addFloatArg(3.5f);
//		m.addStringArg("hello");
//		m.addFloatArg(ofGetElapsedTimef());
//		sender.sendMessage(m);
//	}
}

//--------------------------------------------------------------
void testApp::keyReleased(int key){
	
}

//--------------------------------------------------------------
void testApp::mouseMoved(int x, int y){
//	ofxOscMessage m;
//	m.setAddress("/mouse/position");
//	m.addIntArg(x);
//	m.addIntArg(y);
//	sender.sendMessage(m);
}

//--------------------------------------------------------------
void testApp::mouseDragged(int x, int y, int button){
	
}

//--------------------------------------------------------------
void testApp::mousePressed(int x, int y, int button){
//	ofxOscMessage m;
//	m.setAddress("/mouse/button");
//	m.addStringArg("down");
//	sender.sendMessage(m);
}

//--------------------------------------------------------------
void testApp::mouseReleased(int x, int y, int button){
//	ofxOscMessage m;
//	m.setAddress("/mouse/button");
//	m.addStringArg("up");
//	sender.sendMessage(m);
	
}

//--------------------------------------------------------------
void testApp::windowResized(int w, int h){
	
}

//--------------------------------------------------------------
void testApp::gotMessage(ofMessage msg){
	
}

//--------------------------------------------------------------
void testApp::dragEvent(ofDragInfo dragInfo){
	
}