import tkinter as tk
from tkinter import ttk, filedialog, messagebox, scrolledtext
import re

class ValveAsciiGenerator:
    def __init__(self, root):
        self.root = root
        self.root.title("Valve ASCII Generator")
        self.root.geometry("600x450")
        self.root.configure(bg="#e6f3fa")  # Light blue background

        # Variables
        self.file_path = tk.StringVar()
        self.valve_count = 20  # Fixed to 20 valves
        self.status_text = tk.StringVar(value="Welcome! Select a template file to generate 20 valves.")

        # Style configuration
        style = ttk.Style()
        style.configure("TButton", font=("Arial", 11), padding=8)
        style.configure("TLabel", font=("Arial", 11), background="#e6f3fa")
        style.configure("TEntry", font=("Arial", 11))
        style.configure("Accent.TButton", background="#2196F3", foreground="white", font=("Arial", 11, "bold"))

        # Main frame
        main_frame = ttk.Frame(self.root, padding="30")
        main_frame.grid(row=0, column=0, sticky="nsew")
        self.root.columnconfigure(0, weight=1)
        self.root.rowconfigure(0, weight=1)

        # Title
        ttk.Label(main_frame, text="Valve ASCII File Generator", font=("Arial", 18, "bold"), anchor="center").grid(row=0, column=0, columnspan=2, pady=(0, 20))

        # File selection
        ttk.Label(main_frame, text="Select Template File (.ascii):").grid(row=1, column=0, sticky="w", pady=5)
        file_entry = ttk.Entry(main_frame, textvariable=self.file_path, width=35)
        file_entry.grid(row=2, column=0, sticky="ew", padx=(0, 10))
        ttk.Button(main_frame, text="Browse", command=self.browse_file).grid(row=2, column=1, padx=(0, 0))
        self.create_tooltip(file_entry, "Select the ASCII template file to base the new file on.")

        # Valve count label (fixed to 20)
        ttk.Label(main_frame, text=f"Number of Valves: {self.valve_count}").grid(row=3, column=0, sticky="w", pady=(15, 5))

        # Preview entries button
        preview_entries_btn = ttk.Button(main_frame, text="Preview Entry Count", command=self.preview_entries)
        preview_entries_btn.grid(row=5, column=0, columnspan=2, pady=10)
        self.create_tooltip(preview_entries_btn, "View the total number of entries for 20 valves.")

        # Preview file button
        preview_file_btn = ttk.Button(main_frame, text="Preview File Content", command=self.preview_file)
        preview_file_btn.grid(row=6, column=0, columnspan=2, pady=10)
        self.create_tooltip(preview_file_btn, "View a preview of the generated ASCII file content.")

        # Generate button
        ttk.Button(main_frame, text="Generate ASCII File", command=self.generate_file, style="Accent.TButton").grid(row=7, column=0, columnspan=2, pady=15)

        # Status label
        ttk.Label(main_frame, textvariable=self.status_text, font=("Arial", 10, "italic"), wraplength=500).grid(row=8, column=0, columnspan=2, pady=10)

        # Configure grid weights
        main_frame.columnconfigure(0, weight=1)
        main_frame.columnconfigure(1, weight=0)

    def create_tooltip(self, widget, text):
        tooltip = tk.Toplevel(self.root)
        tooltip.wm_overrideredirect(True)
        tooltip.wm_geometry("+1000+1000")  # Hide initially
        label = tk.Label(tooltip, text=text, background="#ffffe0", relief="solid", borderwidth=1, font=("Arial", 9))
        label.pack()

        def show(event):
            x = widget.winfo_rootx() + 20
            y = widget.winfo_rooty() + widget.winfo_height()
            tooltip.wm_geometry(f"+{x}+{y}")
            tooltip.deiconify()

        def hide(event):
            tooltip.withdraw()

        widget.bind("<Enter>", show)
        widget.bind("<Leave>", hide)

    def browse_file(self):
        file_path = filedialog.askopenfilename(filetypes=[("ASCII Files", "*.ascii"), ("All Files", "*.*")])
        if file_path:
            self.file_path.set(file_path)
            self.status_text.set(f"Selected: {file_path}")

    def preview_entries(self):
        total_entries = 9 + (self.valve_count * 9)  # 9 for _mp_Valve + 9 per valve
        self.status_text.set(f"Will generate {total_entries} entries for {self.valve_count} valves.")

    def generate_content(self):
        file_path = self.file_path.get()

        if not file_path:
            self.status_text.set("Error: No template file selected.")
            return None, "Error: Please select a template ASCII file."

        try:
            # Read the template file
            with open(file_path, "r", encoding="utf-8") as f:
                template_content = f.read()

            # Extract header (up to the first data entry)
            header_match = re.match(r"(.*?)^[IM]\t", template_content, re.MULTILINE | re.DOTALL)
            if not header_match:
                self.status_text.set("Error: Invalid ASCII file format.")
                return None, "Error: Invalid ASCII file format. Could not find header."
            header = header_match.group(1).rstrip()

            # Define attributes for each valve, in the correct order
            attributes = ["Mode", "Open", "Close", "Reset", "OpenFeedback", "Fault", "ValvePosition", "SetPosition", "FlowRateSensor"]

            # Function to generate a single valve entry
            def generate_valve_entry(action, valve_name, bv_index, av_index, active):
                entries = []
                for attr in attributes:
                    if attr in ["Mode", "Open", "Close", "Reset", "OpenFeedback", "Fault"]:
                        # BinaryValue attributes
                        bv_offset = ["Mode", "Open", "Close", "Reset", "OpenFeedback", "Fault"].index(attr)
                        entry = (f"{action}\t{valve_name}.{attr}\tValve\tBACNET output simple\t---\t---\t{active}\t"
                                 f"---\t---\t---\t---\t---\t---\t"
                                 f"BACnet_Device_1.BinaryValue.{bv_index + bv_offset}.Present_Value\t"
                                 f"---\t---\t---\t---\t---\t---\t---\t---\t---\t---\t"
                                 f"---\t---\t---\t---\t---\t---\t---\t---\t---")
                        entries.append(entry)
                    elif attr in ["SetPosition", "FlowRateSensor","ValvePosition"]:
                        # AnalogValue attributes
                        av_offset = ["SetPosition", "FlowRateSensor","ValvePosition"].index(attr)
                        if attr == "SetPosition":
                            # SetPosition with default value 4 and range 0-100
                            entry = (f"{action}\t{valve_name}.{attr}\tValve\tBACNET output simple\t---\t---\t{active}\t"
                                     f"---\t---\t---\t---\t---\t---\t"
                                     f"BACnet_Device_1.AnalogValue.{av_index + av_offset}.Present_Value\t"
                                     f"---\t---\t---\t---\t---\t---\t---\t---\t---\t---\t"
                                     f"---\t---\t---\t---\t---\t---\t---\tRange\t100\t0\t4")
                        else:
                            # ValvePosition and FlowRateSensor (no default or range)
                            entry = (f"{action}\t{valve_name}.{attr}\tValve\tBACNET output simple\t---\t---\t{active}\t"
                                     f"---\t---\t---\t---\t---\t---\t"
                                     f"BACnet_Device_1.AnalogValue.{av_index + av_offset}.Present_Value\t"
                                     f"---\t---\t---\t---\t---\t---\t---\t---\t---\t---\t"
                                     f"---\t---\t---\t---\t---\t---\t---\t---\t---")
                        entries.append(entry)
                return entries

            # Generate the ASCII content
            output_lines = [header]
            output_lines.extend(generate_valve_entry("I", "_mp_Valve", 120, 40, "FALSE"))  # _mp_Valve uses fixed indices
            bv_index = 120  # Start BinaryValue from 126 for Valve_1
            av_index = 40   # Start AnalogValue from 43 for Valve_1
            for i in range(1, self.valve_count + 1):
                output_lines.extend(generate_valve_entry("M", f"Valve_{i}", bv_index, av_index, "TRUE"))
                bv_index += 6  # Increment by 6 for next valve's BinaryValue
                av_index += 3  # Increment by 3 for next valve's AnalogValue

            return output_lines, None

        except Exception as e:
            self.status_text.set(f"Error: {str(e)}")
            return None, f"Error: Failed to generate content: {str(e)}"

    def preview_file(self):
        output_lines, error = self.generate_content()
        if error:
            messagebox.showerror("Error", error)
            return

        # Create a preview window
        preview_window = tk.Toplevel(self.root)
        preview_window.title("Preview ASCII File")
        preview_window.geometry("700x500")
        preview_window.configure(bg="#e6f3fa")

        # Text area for preview
        text_area = scrolledtext.ScrolledText(preview_window, wrap=tk.NONE, font=("Courier New", 10), height=20)
        text_area.pack(padx=15, pady=15, fill="both", expand=True)

        # Show up to 80 lines (header ~40 lines + _mp_Valve (9) + first 2 valves (18))
        preview_lines = output_lines[:200]
        text_area.insert(tk.END, "\n".join(preview_lines))
        text_area.config(state="disabled")  # Make read-only

        # Close button
        ttk.Button(preview_window, text="Close", command=preview_window.destroy).grid(pady=10)

    def generate_file(self):
        output_lines, error = self.generate_content()
        if error:
            messagebox.showerror("Error", error)
            return

        # Prompt for output file location
        output_file = filedialog.asksaveasfilename(
            defaultextension=".ascii",
            filetypes=[("ASCII Files", "*.ascii"), ("All Files", "*.*")],
            title="Save ASCII File"
        )
        if not output_file:
            self.status_text.set("Error: No output file selected.")
            return

        try:
            # Write to output file
            with open(output_file, "w", encoding="utf-8") as f:
                f.write("\n".join(output_lines))

            messagebox.showinfo("Success", f"ASCII file '{output_file}' generated for {self.valve_count} valves.")
            self.status_text.set(f"Generated: {output_file} ({self.valve_count} valves)")

        except Exception as e:
            messagebox.showerror("Error", f"Failed to generate file: {str(e)}")
            self.status_text.set(f"Error: {str(e)}")

# Create and run the GUI
if __name__ == "__main__":
    root = tk.Tk()
    app = ValveAsciiGenerator(root)
    root.mainloop()