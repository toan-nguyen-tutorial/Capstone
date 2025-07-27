import xml.etree.ElementTree as ET
import xml.dom.minidom as minidom

def create_value_element(value):
    val = ET.Element("Value")
    val.text = value
    return val

def generate_bacnet_dampers_values_xml():
    root = ET.Element("Values")
    
    for i in range(5):
        # Comment for each damper set
        comment = ET.Comment(f" Set {i+1} ")
        root.append(comment)
        
        # Calculate starting instance for BINARY_VALUE
        bv_start = 240 + i * 6
        
        # OBJECT_BINARY_VALUE (240-245, 246-251, 252-257, 258-263, 264-269)
        for j in range(6):
            root.append(create_value_element(f"OBJECT_BINARY_VALUE:{bv_start+j}"))
        
        # OBJECT_ANALOG_VALUE (120-121, 122-123, 124-125, 126-127, 128-129)
        av_start = 120 + i * 2
        for j in range(2):
            root.append(create_value_element(f"OBJECT_ANALOG_VALUE:{av_start+j}"))
    
    # Convert to pretty-printed XML
    rough_string = ET.tostring(root, 'utf-8')
    reparsed = minidom.parseString(rough_string)
    pretty_xml = reparsed.toprettyxml(indent="    ")
    
    # Write to file
    with open('bacnet_dampers_values.xml', 'w', encoding='utf-8') as f:
        f.write(pretty_xml)

if __name__ == "__main__":
    generate_bacnet_dampers_values_xml()